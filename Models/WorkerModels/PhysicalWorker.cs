using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Models.WorkerModels
{
    public class PhysicalWorker : Employee
    { 
        [Required]
        public int Strength;

        public PhysicalWorker(Guid id, string name, string lastname, int age, float experience, Address address, WorkerType WorkerType, int strength) : base(id, name, lastname, age, experience, address, WorkerType)
        {
            this.Strength = strength;
        }

        public override float EvaluateEmployee()
        {
            return Experience * (Strength / Age);
        }
    }
}
