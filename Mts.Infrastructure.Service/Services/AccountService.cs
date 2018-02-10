using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Mts.Core.Common;
using Mts.Core.Dto;
using Mts.Core.Dto.Config;
using Mts.Core.Interface;
using Mts.Core.Interface.Service;
using Mts.Core.Resource;
using Mts.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Entity = Mts.Core.Entity;

namespace Mts.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly CrudRepository<Entity.RegistrationRequest> _registrationRequestRepo;
        private readonly CrudRepository<Entity.User> _userRepo;
        private readonly CrudRepository<Entity.Business> _businessRepo;
        private readonly CrudRepository<Entity.UserBusiness> _userBusinessRepo;
        private readonly IMapper _mapper;
        private readonly ICryptography _crypto;
        private readonly IEmailService _emailService;
        private readonly AppSettingConfig _config;

        public AccountService(CrudRepository<Entity.RegistrationRequest> registrationRequestRepo,
                              CrudRepository<Entity.User> userRepo,
                              CrudRepository<Entity.Business> businessRepo,
                              CrudRepository<Entity.UserBusiness> userBusinessRepo,
                              IMapper mapper,
                              ICryptography crypto,
                              IEmailService emailService,
                              IOptions<AppSettingConfig> config)
        {
            _registrationRequestRepo = registrationRequestRepo;
            _userRepo = userRepo;
            _businessRepo = businessRepo;
            _userBusinessRepo = userBusinessRepo;
            _crypto = crypto;
            _mapper = mapper;
            _emailService = emailService;
            _config = config.Value;

        }

        public async Task<ApiResponse<string>> RequestRegistration(string email)
        {
            var response = new ApiResponse<string>();
            using (var tx = _registrationRequestRepo.Context.Database.BeginTransaction())
            {
                try
                {
                    var isEmailAlreadyRegistered = _userRepo.List(i => i.Email == email).Any();
                    if (isEmailAlreadyRegistered)
                    {
                        response.Success = false;
                        response.ErrorMesssage.Add(MtsResource.InvalidEmail);
                    }
                    if (response.Success)
                    {
                        var registrationRequest = _registrationRequestRepo.List(i => i.Email == email).FirstOrDefault();
                        string token = RandomGenerator.GenerateString(50);

                        if (registrationRequest != null)
                        {
                            registrationRequest.Token = token;
                            await _registrationRequestRepo.Update(registrationRequest);
                        }
                        else
                        {
                            await _registrationRequestRepo.Save(new Entity.RegistrationRequest
                            {
                                Email = email,
                                Token = token,
                                CreatedDate = DateTime.UtcNow,
                                UpdatedDate = DateTime.UtcNow
                            });
                        }

                        _emailService.Send(new EmailBody
                        {
                            Content = GenerateRegistrationRequestBody(token, email),
                            From = "francis.cebu@basecamptech.ph",
                            To = email,
                            Subject = "Registration Request"
                        });

                        tx.Commit();
                    }

                }
                catch (Exception e)
                {
                    response.Success = false;
                    response.ErrorMesssage.Add(e.GetBaseException().Message);
                    tx.Rollback();
                }
            }

            return response;
        }

        public async Task<ApiResponse<User>> RegisterUser(User user)
        {
            var response = new ApiResponse<User> ();
            var userEntity = _mapper.Map<Entity.User>(user);
            var businessEntity = _mapper.Map<Entity.Business>(user.Business);

            var isEmailExist = _userRepo.List(i => i.Email == user.Email).Any();
            if (isEmailExist)
            {
                response.Success = false;
                response.ErrorMesssage.Add(MtsResource.InvalidEmail);
            }

            var isBusinessNameExist = _businessRepo.List(i => i.Name == user.Business.Name).Any();
            if (isBusinessNameExist)
            {
                response.Success = false;
                response.ErrorMesssage.Add(MtsResource.InvalidBusinessName);
            }

            if (response.Success)
            {
                using (var tx = _registrationRequestRepo.Context.Database.BeginTransaction())
                {
                    try
                    {
                        userEntity.Password = _crypto.CalculateHash(user.Password);
                        await _userRepo.Save(userEntity);
                        await _businessRepo.Save(businessEntity);
                        await _userBusinessRepo.Save(new Entity.UserBusiness
                        {
                            BusinessId = businessEntity.Id,
                            UserId = userEntity.Id
                        });
                        user = _mapper.Map<User>(userEntity);
                        user.Business = _mapper.Map<Business>(businessEntity);
                        response.DataResponse = user;

                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        response.Success = false;
                        response.ErrorMesssage.Add(e.GetBaseException().Message);
                        tx.Rollback();
                    }
                }
            }


            return response;
        }

        public ApiResponse<bool> ValidateEmailToken(RegistrationRequest model)
        {
            var response = new ApiResponse<bool>();
            var isEmailTokenMatch = _registrationRequestRepo.List(i => i.Email == model.Email && i.Token == model.Token).Any();
            if (!isEmailTokenMatch)
            {
                response.Success = false;
                response.ErrorMesssage.Add(MtsResource.InvalidToken);
            }

            var isEmailRegistered = _userRepo.List(i => i.Email == model.Email).Any();
            if (isEmailRegistered)
            {
                response.Success = false;
                response.ErrorMesssage.Add(MtsResource.InvalidEmail);
            }

            return response;
        }

        private string GenerateRegistrationRequestBody(string token,string email)
        {
            var body = MtsResource.RegistrationRequest;
            body = body.Replace(MtsResource.LinkTkn, $"{_config.Url}/register?t={token}&e={email}");
            return body;
        }
    }
}
