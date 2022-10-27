using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
