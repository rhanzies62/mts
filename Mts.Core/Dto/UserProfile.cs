using Mts.Core.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Dto
{
    public class UserProfile : BaseUser
    {
        public string ContactNumber { get; set; }
        public Address Address { get; set; }
    }
}
