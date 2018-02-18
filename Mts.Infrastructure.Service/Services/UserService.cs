using Microsoft.EntityFrameworkCore;
using Mts.Core.Interface.Repository;
using Mts.Core.Resource;
using Mts.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dto = Mts.Core.Dto;
using entity = Mts.Core.Entity;
using System.Linq;
using Mts.Core.Interface.Service;
using AutoMapper;

namespace Mts.Infrastructure.Service.Services
{
    public class UserService : IUserService
    {
        private readonly CrudRepository<entity.User> _userRepo;
        private readonly CrudRepository<entity.ApplicationFeature> _appFeatureRepo;
        private readonly CrudRepository<entity.Address> _addressRepo;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(CrudRepository<entity.User> userRepo,
                           CrudRepository<entity.ApplicationFeature> appFeatureRepo,
                           CrudRepository<entity.Address> addressRepo,
                           IUserRepository userRepository,
                           IMapper mapper)
        {
            _userRepo = userRepo;
            _appFeatureRepo = appFeatureRepo;
            _addressRepo = addressRepo;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<dto.UserSecurityProfile> RetrieveUserSecurityProfile(int userid)
        {
            var user = _userRepo.List(i => i.Id == userid).FirstOrDefault();
            var response = new dto.UserSecurityProfile()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserId = user.Id
            };
            response.SecurityProfile = (await _userRepository.GetUserSecurityProfileAsync(userid)).Select(i => new dto.SecurityProfile
            {
                Name = i.Name,
                Route = i.RouteAddress
            });

            return response;
        }

        public async Task<dto.ApiResponse<bool>> UpdateProfile(dto.UserProfile model)
        {
            var apiResponse = new dto.ApiResponse<bool>();
            try
            {
                var userentity = _mapper.Map<entity.User>(model);
                await _userRepo.Update(userentity);

                var addressEntity = _mapper.Map<entity.Address>(model.Address);
                await _addressRepo.Update(addressEntity);

            }catch (Exception e)
            {
                apiResponse.Success = false;
                apiResponse.ErrorMesssage.Add(MtsResource.ServiceInternalServerError);
            }

            return apiResponse;
        }

        public dto.UserProfile RetrieveProfile(int userid)
        {
            var userEntity = _userRepo.List(i => i.Id == userid).FirstOrDefault();
            var result = _mapper.Map<dto.UserProfile>(userEntity);
            result.Address = _mapper.Map<dto.Address>(result.Address);
            return result;
        }
    }
}
