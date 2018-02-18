using Mts.Core.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Dto
{
    public class User : BaseUser
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public string ValidationToken { get; set; }

        public Business Business { get; set; }
    }
}
