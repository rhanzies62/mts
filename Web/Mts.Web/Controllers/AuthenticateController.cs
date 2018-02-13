using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mts.Core.Dto;
using Mts.Core.Dto.Config;
using Mts.Core.Interface.Service;

namespace Mts.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Authenticate")]
    public class AuthenticateController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IOptions<AppSettingConfig> _config;
        private readonly IMemoryCache _memoryCache;
        public AuthenticateController(IAccountService accountService,
                                      IOptions<AppSettingConfig> config,
                                      IMemoryCache memoryCache)
        {
            _accountService = accountService;
            _config = config;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserLogin model)
        {
            var response = new ApiResponse<AuthToken>();
            var result = _accountService.AuthenticateUser(model);
            response.Success = result.Success;
            response.ErrorMesssage = result.ErrorMesssage;

            return CreateToken(response, result);

        }

        [HttpPut]
        public IActionResult Put([FromBody]string refreshToken)
        {
            var response = new ApiResponse<AuthToken>();
            var result = _accountService.ReAuthenticateUser(refreshToken);
            response.Success = result.Success;
            response.ErrorMesssage = result.ErrorMesssage;

            return CreateToken(response, result);
        }

        private IActionResult CreateToken(ApiResponse<AuthToken> response, ApiResponse<LoginDetail> result)
        {
            if (result.Success)
            {
                var claims = new[] {
                            new Claim("Name", result.DataResponse.Name),
                            new Claim("BusinessId", result.DataResponse.BusinessId.ToString()),
                            new Claim("Id", result.DataResponse.Id.ToString()),
                            new Claim("k",result.DataResponse.AccessToken)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.EncryptionKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                                    issuer: _config.Value.Url,
                                    audience: _config.Value.Url,
                                    claims: claims,
                                    expires: DateTime.Now.AddMinutes(30),
                                    signingCredentials: creds);

                var cacheEntryOptions = new MemoryCacheEntryOptions();
                _memoryCache.Set(result.DataResponse.AccessToken, token, cacheEntryOptions);

                response.DataResponse = new AuthToken()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = result.DataResponse.RefreshToken
                };
            }
            return new OkObjectResult(response);
        }

    }
}