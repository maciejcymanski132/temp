using Models.Interfaces;

namespace Models.WorkerModels
{
    public class OfficeWorker : IEmployee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public float Experience { get; set; }

        public Address Address { get; set; }

        public WorkerType WorkerType { get; set; }

        public OfficeStation OfficeStation { get; set; }

        public int Intelligence { get; set; }

        public OfficeWorker(Guid id, string name, string lastName, float experience, Address address, WorkerType workerType, OfficeStation officeStation, int intelligence)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Experience = experience;
            Address = address;
            WorkerType = workerType;
            OfficeStation = officeStation;
            Intelligence = intelligence;
        }
    }
}
