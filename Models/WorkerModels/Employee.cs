using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WorkerModels
{
    public class Employee
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

        public virtual void EvaluateEmployee() {}

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

    }
}
