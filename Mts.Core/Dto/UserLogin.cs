using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Dto
{
    public class UserLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }
}
