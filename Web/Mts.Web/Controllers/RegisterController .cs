using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Mts.Core.Dto;
using Mts.Core.Dto.Config;
using Mts.Core.Interface.Service;
using Mts.Core.Resource;
using Dto = Mts.Core.Dto;
namespace Mts.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Registration")]
    public class RegisterController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;
        public RegisterController(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Dto.User model)
        {
            if (ModelState.IsValid)
            {
                //register user. if user successfully registered. need to create role
                var registrationResult = await _accountService.RegisterUser(model);
                if (registrationResult.Success)
                {
                    //create an initial role for the user with assigned features.
                    var roleCreationResponse = await _roleService.CreateInitialAdminRole(new Dto.Role
                    {
                        BusinessId = registrationResult.DataResponse.Business.Id,
                        UserId = registrationResult.DataResponse.Id,
                        Name = MtsResource.AdminRole
                    });
                    return new OkObjectResult(roleCreationResponse);
                }
                else
                {
                    return new OkObjectResult(registrationResult);
                }
            }
            var errMessage = ModelState.Values.SelectMany(v => v.Errors).Select(i => i.ErrorMessage).ToList();
            return new OkObjectResult(new ApiResponse<bool>() {
                Success = false,
                ErrorMesssage = errMessage
            });
        }
    }
}