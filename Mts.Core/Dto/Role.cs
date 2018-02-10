using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mts.Core.Dto
{
    public class Role
    {
        string _name;
        [Required]
        public string Name
        {
            get { return _name.ToLower(); }
            set { _name = value; }
        }
        public int BusinessId { get; set; }
        public int UserId { get; set; }
        public int Id { get; set; }
    }
}
