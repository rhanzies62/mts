using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mts.Core.Entity
{
    public class RoleApplicationFeature : IAuditDate, IAuditUser
    {
        [Key,Column(Order = 1)]
        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        [Key, Column(Order = 2)]
        [Required]
        [ForeignKey("ApplicationFeature")]
        public int ApplicationFeatureId { get; set; }

        [Required]
        public bool FullAccess { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public virtual Role Role { get; set; }
        public virtual ApplicationFeature ApplicationFeature { get; set; }
    }
}
