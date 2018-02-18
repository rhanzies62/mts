using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using dto = Mts.Core.Dto;

namespace Mts.Core.Interface.Service
{
    public interface IUserService
    {
        Task<dto.UserSecurityProfile> RetrieveUserSecurityProfile(int userid);
        Task<dto.ApiResponse<bool>> UpdateProfile(dto.UserProfile model);
        dto.UserProfile RetrieveProfile(int userid);
    }
}
