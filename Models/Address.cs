using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Address
    {
        public string Street;
        public string BuildingNumber;
        public string Apartment;
        public string City;

        [JsonConstructor]
        public Address()
        {
        }

        public Address(string buildingNumber,string street, string apartment, string city)
        {
            this.BuildingNumber = buildingNumber;
            this.Street = street;
            this.Apartment = apartment;
            this.City = city;
        }
    }
}
