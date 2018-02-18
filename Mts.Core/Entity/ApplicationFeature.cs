using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Entity
{
    /// <summary>
    /// This class is only accessible by developers. only existing features are
    /// </summary>
    public class ApplicationFeature: IAuditDate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public bool IsPanel { get; set; }

        [Required]
        public bool IsParent { get; set; }

        public int ParentId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string RouteAddress { get; set; }
    }
}
