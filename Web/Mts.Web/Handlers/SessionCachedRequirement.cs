using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mts.Web.Handlers
{
    public class SessionCachedRequirement : IAuthorizationRequirement
    {
        public SessionCachedRequirement()
        {
        }
    }
}
