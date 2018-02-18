using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Entity
{
    public class LoginLog : IAuditDate
    {
        public LoginLog()
        {

        }
        public LoginLog(string ipaddress)
        {
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
            Success = true;
            IpAddress = ipaddress;
        }
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public int UserId { get; set; }
        public bool Success { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
