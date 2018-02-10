using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Dto
{
    public class User
    {
        public int Id { get; set; }

        string _firstname;
        [Required]
        public string FirstName
        {
            get
            {
                return _firstname.ToLower();
            }
            set { _firstname = value; }
        }

        string _lastname;
        [Required]
        public string LastName
        {
            get
            {
                return _lastname.ToLower();
            }
            set { _lastname = value; }
        }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public Business Business { get; set; }
    }
}
