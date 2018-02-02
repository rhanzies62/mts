using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mts.Core.Entity
{
    public class UserBusiness : IAuditDate
    {
        [Key,Column(Order = 1)]
        [Required]
        [ForeignKey("Business")]
        public int BusinessId { get; set; }

        [Key, Column(Order = 2)]
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual Business Business { get; set; }

        public virtual User User { get; set; }
    }
}
