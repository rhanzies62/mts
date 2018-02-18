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
        public async Task<IActionResult> Post([FromBody]UserLogin model)
        {
            var response = new ApiResponse<AuthToken>();
            model.IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var result = await _accountService.AuthenticateUser(model);
            response.Success = result.Success;
            response.ErrorMesssage = result.ErrorMesssage;

            return CreateToken(response, result);

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]string refreshToken)
        {
            if (CheckRefreshTokenIfExist(refreshToken))
            {
                var response = new ApiResponse<AuthToken>();
                var result = await _accountService.ReAuthenticateUser(refreshToken, Request.HttpContext.Connection.RemoteIpAddress.ToString());
                response.Success = result.Success;
                response.ErrorMesssage = result.ErrorMesssage;
                return CreateToken(response, result);
            }
            else
            {
                return new OkObjectResult(new ApiResponse<AuthToken>() {
                    Success = false,
                     ErrorMesssage = new List<string>() {
                         "Refersh token is not valid"
                     }
                });
            }

        }

        #region Private Methods
        private IActionResult CreateToken(ApiResponse<AuthToken> response, ApiResponse<LoginDetail> result)
        {
            if (result.Success)
            {
                var claims = new[] {
                            new Claim("Name", result.DataResponse.Name),
                            new Claim("BusinessId", result.DataResponse.BusinessId.ToString()),
                            new Claim("Id", result.DataResponse.Id.ToString()),
                            new Claim("k",result.DataResponse.RefreshToken)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Value.EncryptionKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                                    issuer: _config.Value.Url,
                                    audience: _config.Value.Url,
                                    claims: claims,
                                    expires: DateTime.Now.AddMinutes(30),
                                    signingCredentials: creds);
                string _token = new JwtSecurityTokenHandler().WriteToken(token);

                response.DataResponse = new AuthToken()
                {
                    Token = _token,
                    RefreshToken = result.DataResponse.RefreshToken
                };

                var cacheEntryOptions = new MemoryCacheEntryOptions();
                _memoryCache.Set(result.DataResponse.RefreshToken, response.DataResponse, cacheEntryOptions);
            }
            return new OkObjectResult(response);
        }

        private bool CheckRefreshTokenIfExist(string refreshToken)
        {
            AuthToken token;
            _memoryCache.TryGetValue<AuthToken>(refreshToken, out token);
            _memoryCache.Remove(refreshToken);
            return token != null;
        }
        #endregion
    }
}