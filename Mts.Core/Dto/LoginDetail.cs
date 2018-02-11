using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Dto
{
    public class LoginDetail
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public string Name { get; set; }
        public string RefreshToken { get; set; }
    }
}
