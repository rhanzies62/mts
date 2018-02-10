using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mts.Core.Dto;
using Mts.Core.Interface.Service;

namespace Mts.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/RegistrationRequest")]
    public class RegistrationRequestController : Controller
    {
        public readonly IAccountService _accountService;
        public RegistrationRequestController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<IActionResult> Post([FromBody]RegistrationRequest model)
        {
            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                var result = await _accountService.RequestRegistration(model.Email);
                return new OkObjectResult(result);
            }
            else
            {
                ModelState.AddModelError("Email", "Email address is requried");
            }
            return new BadRequestObjectResult(ModelState);
        }
    }
}