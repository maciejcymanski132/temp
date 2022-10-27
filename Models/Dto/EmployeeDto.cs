using Models.WorkerModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Dto
{
        public class EmployeeDto
        {
        public EmployeeDto(string name, string lastName, int age, float experience, Address address, WorkerType WorkerType, int strength, int commission, int efficiency,int intelligence, Guid officeStation ) 
        {
            this.Name = name;
            this.LastName = lastName;
            this.Age = age;
            this.Experience = experience;
            this.Address = address;
            this.WorkerType = WorkerType;
            this.Strength = strength;
            this.Commission = commission;
            this.OfficeStation = officeStation;
            this.Efficiency = efficiency;
            this.Intelligence = intelligence;
        }

        [JsonConstructor]
        public EmployeeDto() { }


            public string Name { get; set; }

            public string LastName { get; set; }

            [Range(18,99)]
            public int Age { get; set; }

            [Range(1,25)]
            public float Experience { get; set; }
            
        [Required]
            public Address Address { get; set; }

            public WorkerType WorkerType { get; set; }

            [Range(1,100)]
            public int? Strength { get; set; }

            [Range(1,50)]
            public int? Commission { get; set; }

            [Range(1,120)]
            public int? Efficiency { get; set; }
            [Range(70,150)]
            public int? Intelligence { get; set; }

            public Guid? OfficeStation { get; set; }
        }
    }
