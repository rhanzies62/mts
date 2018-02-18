using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Dto.Base
{
    public abstract class BaseUser
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
    }
}
