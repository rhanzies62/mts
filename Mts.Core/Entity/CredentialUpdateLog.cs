using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Entity
{
    public class CredentialUpdateLog :IAuditDate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        public string EmailAddress { get; set; }

        [Required]
        public bool IsPasswordUpdate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
