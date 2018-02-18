using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using Mts.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mts.Web.Handlers
{
    public class SessionCacheHandler : AuthorizationHandler<SessionCachedRequirement>
    {
        private readonly CacheSingleton _cache;
        public SessionCacheHandler(CacheSingleton cache)
        {
            _cache = cache;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SessionCachedRequirement requirement)
        {
            var claims = context.User.Claims.Where(i => i.Type == "k").First();

            AuthToken toks;
            _cache.MemCache.TryGetValue<AuthToken>(claims.Value, out toks);
            if (toks != null)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
