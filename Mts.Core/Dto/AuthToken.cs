using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Dto
{
    public class AuthToken
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
