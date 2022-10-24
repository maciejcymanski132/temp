using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WorkerModels
{
    public class PhysicalWorker : IEmployee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public float Experience { get; set; }

        public Address Address { get; set; }

        public WorkerType WorkerType { get; set; }

        public int Strength;

        public PhysicalWorker(Guid id, string name, string lastName, float experience, Address address, WorkerType workerType, int strength)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Experience = experience;
            Address = address;
            WorkerType = workerType;
            Strength = strength;
        }
    }
}
