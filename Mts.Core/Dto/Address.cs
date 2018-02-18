using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Dto
{
    public class Address
    {
        public int Id { get; set; }
        public string AddressLineOne { get; set; }
        public string StreetName { get; set; }
        public string District { get; set; }
        public string City { get; set; }
    }
}
