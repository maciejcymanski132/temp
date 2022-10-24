using Models.Interfaces;

namespace Models
{
    public class Trader : IEmployee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public float Experience { get; set; }

        public Address Address { get; set; }

        public WorkerType WorkerType { get; set; }

        public float Commission { get; set; }

        public Efficiency Efficiency { get; set; }

        public Trader(Guid id, string name, string lastname,float experience, Address address, WorkerType workertype, float commission, Efficiency efficiency)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastname;
            this.Experience = experience;
            this.Address = address;
            this.WorkerType = workertype;
            this.Commission = commission;
            this.Efficiency = efficiency;
        }
    }
}