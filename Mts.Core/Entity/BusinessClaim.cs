using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mts.Core.Entity
{
    public class BusinessClaim : IAuditDate, IAuditUser
    {
        [Key,Column(Order = 0)]
        [Required]
        [ForeignKey("Claim")]
        public int ClaimId { get; set; }

        [Key, Column(Order = 1)]
        [Required]
        [ForeignKey("Business")]
        public int BusinessId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        [Required]
        [MaxLength(50)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual Claim Claim { get; set; }

        public virtual Business Business { get; set; }
    }
}
