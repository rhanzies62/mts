using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Dto
{
    public class UserSecurityProfile
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<SecurityProfile> SecurityProfile { get; set; }
    }

    public class SecurityProfile
    {
        public string Route { get; set; }
        public string Name { get; set; }
    }
}
