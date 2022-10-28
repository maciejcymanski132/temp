using System.Text.Json.Serialization;

namespace Models
{
    public class OfficeStation
    {
        public OfficeStation(Guid id, string signature, Guid assignedEmployee)
        {
            this.Id = id;
            this.AssignedEmployee = assignedEmployee;
            this.Signature = signature;
        }

        public  Guid Id { get; set; }

        public Guid AssignedEmployee { get; set; }

        public string Signature { get; set; }
    }
}
