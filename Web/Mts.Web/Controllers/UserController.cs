using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mts.Core.Dto;
using Mts.Core.Interface.Service;

namespace Mts.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "SessionCache")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserProfile model)
        {
            var id = User.Claims.Where(i => i.Type == "Id").First();
            model.Id = int.Parse(id.Value);
            var result = await _userService.UpdateProfile(model);
            return new OkObjectResult(result);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var id = User.Claims.Where(i => i.Type == "Id").First();
            var result = _userService.RetrieveProfile(int.Parse(id.Value));
            return new OkObjectResult(result);
        }

    }
}