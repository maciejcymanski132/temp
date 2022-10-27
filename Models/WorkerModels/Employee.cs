using System.ComponentModel.DataAnnotations;

namespace Models.WorkerModels
{
    public class Employee : IEmployee
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        public float Experience { get; set; }

        public Address Address { get; set; }

        public WorkerType WorkerType { get; set; }


        public Employee(Guid id, string name, string lastName, int age, float experience, Address address, WorkerType workerType)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Age = age;
            Experience = experience;
            Address = address;
            WorkerType = workerType;
        }

        public virtual float EvaluateEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
