using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Dto
{
    public class RoleApplicationFeature
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public int ApplicationFeatureId { get; set; }

        [Required]
        public bool FullAccess { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string UpdatedBy { get; set; }
    }
}
