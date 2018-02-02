using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mts.Core.Entity
{
    public class UserRole : IAuditDate
    {
        [Key, Column(Order = 0)]
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }
    }
}
