using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mts.Core.Entity
{
    public class User : IAuditDate
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int ErrorCount { get; set; }

        [Required]
        public bool IsEmailValidated { get; set; }

        [Required]
        public DateTime ValidatedDate { get; set; }

        [Required]
        public string ValidationToken { get; set; }

        public string ContactNumber { get; set; }

        public virtual UserBusiness UserBusiness { get; set; }

        public virtual Address Address { get; set; }

    }
}
