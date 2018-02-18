using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mts.Core.Interface.Service;

namespace Mts.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/UserSecurityProfile")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "SessionCache")]
    public class UserSecurityProfileController : Controller
    {
        private readonly IUserService _userService;
        public UserSecurityProfileController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var id = User.Claims.Where(i => i.Type == "Id").First();
            var result = await _userService.RetrieveUserSecurityProfile(int.Parse(id.Value));
            return new OkObjectResult(result);
        }
    }
}