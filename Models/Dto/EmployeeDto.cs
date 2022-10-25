using Models.WorkerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Dto
{
        public class EmployeeDto
        {
        public EmployeeDto(Guid id, string name, string lastName, int age, float experience, Address address, WorkerType workerType, int strength, int commission, int efficiency,int intelligence, Guid officeStation ) 
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
            this.Experience = experience;
            this.Address = address;
            this.WorkerType = workerType;
            this.Strength = strength;
            this.Commission = commission;
            this.OfficeStation = officeStation;
            this.Efficiency = efficiency;
            this.Intelligence = intelligence;
        }

        [JsonConstructor]
        public EmployeeDto() { }


        public Guid Id { get; set; }

            public string Name { get; set; }

            public string LastName { get; set; }

            public int Age { get; set; }

            public float Experience { get; set; }

            public Address Address { get; set; }

            public WorkerType WorkerType { get; set; }

            public int? Strength { get; set; }

            public int? Commission { get; set; }

            public int? Efficiency { get; set; }

            public int? Intelligence { get; set; }

            public Guid? OfficeStation { get; set; }
        }
    }
