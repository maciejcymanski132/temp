using Models.WorkerModels;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Trader : Employee
    {
        [Required]
        public float Commission { get; set; }

        [Required]
        public Efficiency Efficiency { get; set; }

        public Trader(Guid id, string name,  string lastname, int age, float experience, Address address, WorkerType workertype,float commission, Efficiency efficiency) : base(id,name,lastname,age,experience,address,workertype)
        {
            this.Commission = commission;
            this.Efficiency = efficiency;
        }

    }
}