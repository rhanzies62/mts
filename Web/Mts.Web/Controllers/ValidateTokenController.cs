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
    [Route("api/ValidateToken")]
    public class ValidateTokenController : Controller
    {
        private readonly IAccountService _accountService;
        public ValidateTokenController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Post([FromBody]RegistrationRequest model)
        {
            if (ModelState.IsValid)
                return new OkObjectResult(_accountService.ValidateEmailToken(model));
            else
                return new BadRequestObjectResult(ModelState);
        }
    }
}