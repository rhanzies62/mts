using AutoMapper;
using Mts.Core.Interface.Service;
using Mts.Core.Resource;
using Mts.Infrastructure.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto = Mts.Core.Dto;
using Entity = Mts.Core.Entity;

namespace Mts.Infrastructure.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly CrudRepository<Entity.Role> _roleRepo;
        private readonly CrudRepository<Entity.UserRole> _userRoleRepo;
        private readonly CrudRepository<Entity.ApplicationFeature> _appFeatureRepo;
        private readonly CrudRepository<Entity.RoleApplicationFeature> _roleAppRepo;
        private readonly IMapper _mapper;

        public RoleService(CrudRepository<Entity.Role> roleRepo,
                           CrudRepository<Entity.UserRole> userRoleRepo,
                           CrudRepository<Entity.ApplicationFeature> appFeatureRepo,
                           CrudRepository<Entity.RoleApplicationFeature> roleAppRepo,
                           IMapper mapper)
        {
            _roleRepo = roleRepo;
            _userRoleRepo = userRoleRepo;
            _appFeatureRepo = appFeatureRepo;
            _roleAppRepo = roleAppRepo;
            _mapper = mapper;
        }

        public async Task<Dto.ApiResponse<object>> AssignRoleApplicationFeatureForUser(Dto.RoleApplicationFeature model)
        {
            var response = new Dto.ApiResponse<object>();
            var roleAppEntity = _mapper.Map<Entity.RoleApplicationFeature>(model);
            var isRoleAlreadyAssigned = _roleAppRepo.List(i => i.RoleId == model.RoleId && i.ApplicationFeatureId == model.ApplicationFeatureId).Any();
            if (isRoleAlreadyAssigned)
            {
                response.Success = false;
                response.ErrorMesssage.Add(MtsResource.RoleAlreadyAssignToFeature);
            }

            if (response.Success)
            {
                await _roleAppRepo.Save(roleAppEntity);
            }
            return response;
        }

        public async Task<Dto.ApiResponse<object>> AssignRoleToUser(Dto.Role model)
        {
            var response = new Dto.ApiResponse<object>();

            var isRoleAlreadyassignedToUser = _userRoleRepo.List(i => i.RoleId == model.Id && i.UserId == model.UserId).Any();
            if (isRoleAlreadyassignedToUser)
            {
                response.Success = false;
                response.ErrorMesssage.Add(MtsResource.RoleAlreadyAssignToUser);
            }
            
            var userRoleEntity = _mapper.Map<Entity.UserRole>(model);
            userRoleEntity.RoleId = model.Id;

            await _userRoleRepo.Save(userRoleEntity);

            return response;
        }

        public async Task<Dto.ApiResponse<object>> CreateInitialAdminRole(Dto.Role model)
        {
            var response = new Dto.ApiResponse<object>();
            using (var tx = _roleRepo.Context.Database.BeginTransaction())
            {
                try
                {
                    //Create initial role for the user
                    var roleEntity = _mapper.Map<Entity.Role>(model);
                    var createRoleResponse = await this.CreateRole(model);
                    if (createRoleResponse.Success)
                    {
                        //assign the role to the user
                        model = createRoleResponse.DataResponse;
                        var assignedRoleToUserResponse = await this.AssignRoleToUser(model);

                        if (assignedRoleToUserResponse.Success)
                        {
                            //assigned all of the feature to the user
                            var appFeatures = _appFeatureRepo.List();
                            foreach (var appFeature in appFeatures)
                            {
                                await this.AssignRoleApplicationFeatureForUser(new Dto.RoleApplicationFeature
                                {
                                    ApplicationFeatureId = appFeature.Id,
                                    RoleId = model.Id,
                                    FullAccess = true,
                                    CreatedBy = MtsResource.AdminCreateUpdateBy,
                                    UpdatedBy = MtsResource.AdminCreateUpdateBy
                                });
                            }

                            tx.Commit();
                        }
                        else
                        {
                            response.Success = false;
                            response.ErrorMesssage = assignedRoleToUserResponse.ErrorMesssage;
                        }
                    }
                    else
                    {
                        response.Success = false;
                        response.ErrorMesssage = createRoleResponse.ErrorMesssage;
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

        public async Task<Dto.ApiResponse<Dto.Role>> CreateRole(Dto.Role model)
        {
            var response = new Dto.ApiResponse<Dto.Role>();
            if (string.IsNullOrWhiteSpace(model.Name) || model.BusinessId == 0)
            {
                response.Success = false;
                response.ErrorMesssage.Add(MtsResource.InvalidRoleBusiness);
            }

            var isRoleExist = _roleRepo.List(i => i.Name == model.Name && i.BusinessId == model.BusinessId).Any();
            if (isRoleExist)
            {
                response.Success = false;
                response.ErrorMesssage.Add(MtsResource.RoleAlreadyExist);
            }

            if (response.Success)
            {
                var roleEntity = _mapper.Map<Entity.Role>(model);
                await _roleRepo.Save(roleEntity);
                response.DataResponse = _mapper.Map<Dto.Role>(roleEntity);
                response.DataResponse.UserId = model.UserId;
            }

            return response;
        }
    }
}
