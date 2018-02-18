using Mts.Core.Interface.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Entity
{
    public class Address : IAuditDate,IAuditUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AddressLineOne { get; set; }

        [Required]
        public string StreetName { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string UpdatedBy { get; set; }
    }
}
