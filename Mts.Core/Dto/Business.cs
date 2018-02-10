using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Dto
{
    public class Business
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string NatureOfBusiness { get; set; }

        public string Website { get; set; }
    }
}
