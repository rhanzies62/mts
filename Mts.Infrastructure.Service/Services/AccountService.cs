using AutoMapper;
using Mts.Core.Common;
using Mts.Core.Dto;
using Mts.Core.Interface;
using Mts.Core.Interface.Service;
using Mts.Core.Resource;
using Mts.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = Mts.Core.Entity;

namespace Mts.Infrastructure.Service
{
    public class AccountService : IAccountService
    {
        private readonly CrudRepository<Entity.RegistrationRequest> _registrationRequestRepo;
        private readonly IMapper _mapper;
        private readonly ICryptography _crypto;
        private readonly IEmailService _emailService;

        public AccountService(CrudRepository<Entity.RegistrationRequest> registrationRequestRepo,
                              IMapper mapper,
                              ICryptography crypto,
                              IEmailService emailService)
        {
            _registrationRequestRepo = registrationRequestRepo;
            _crypto = crypto;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<ApiResponse> RequestRegistration(string email)
        {
            var response = new ApiResponse();
            using (var tx = _registrationRequestRepo.Context.Database.BeginTransaction())
            {
                try
                {
                    var checkEmailExist = _registrationRequestRepo.List(i => i.Email == email).Any();
                    if (!checkEmailExist)
                    {
                        await _registrationRequestRepo.Save(new Entity.RegistrationRequest
                        {
                            Email = email,
                            Token = RandomGenerator.GenerateString(50),
                            CreatedDate = DateTime.UtcNow,
                            UpdatedDate = DateTime.UtcNow
                        });

                        _emailService.Send(new EmailBody
                        {
                            Content = MtsResource.RegistrationRequest,
                            From = "francis.cebu@basecamptech.ph",
                            To = email,
                            Subject = "Registration Request"
                        });
                    }
                    else
                    {
                        response.Success = false;
                        response.ErrorMesssage.Add("Registration link is already sent.");
                    }
                    tx.Commit();
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
    }
}
