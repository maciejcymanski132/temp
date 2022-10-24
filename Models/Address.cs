using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        readonly string Street;
        readonly string BuildingNumber;
        readonly string Apartment;
        readonly string City;

        public Address(string buildingNumber,string street, string apartment, string city)
        {
            BuildingNumber = buildingNumber;
            Street = street;
            Apartment = apartment;
            City = city;
        }
    }
}
