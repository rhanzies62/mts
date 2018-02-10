using Mts.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mts.Core.Interface.Service
{
    public interface IRoleService
    {
        Task<ApiResponse<object>> CreateInitialAdminRole(Role model);
        Task<ApiResponse<Role>> CreateRole(Role model);
        Task<ApiResponse<object>> AssignRoleToUser(Role model);
        Task<ApiResponse<object>> AssignRoleApplicationFeatureForUser(RoleApplicationFeature model);
    }
}
