using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Entity
{
    public class Business : IAuditDate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string NatureOfBusiness { get; set; }

        [Url]
        public string Website { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        public ICollection<BusinessClaim> BusinessClaims { get; set; }
        public ICollection<UserBusiness> UserBusinesses { get; set; }
    }
}
