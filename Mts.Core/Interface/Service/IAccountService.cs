using Mts.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mts.Core.Interface.Service
{
    public interface IAccountService
    {
        Task<ApiResponse<string>> RequestRegistration(string email);
        ApiResponse<bool> ValidateEmailToken(RegistrationRequest model);
        Task<ApiResponse<User>> RegisterUser(User user);
        ApiResponse<LoginDetail> AuthenticateUser(UserLogin model);
    }
}
