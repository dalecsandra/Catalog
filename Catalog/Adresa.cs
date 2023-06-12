using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsCatalog
{
    /// <summary>
    /// Reprezinta o adresa.
    /// </summary>
    class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public Address(string city, string street, string number)
        {
            City = city;
            Street = street;
            Number = number;
        }
    }
}