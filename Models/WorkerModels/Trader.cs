using Models.WorkerModels;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Trader : Employee
    {
        public float Commission { get; set; }

        public Efficiency Efficiency { get; set; }

        public Trader(Guid id, string name,  string lastname, int age, float experience, Address address, WorkerType WorkerType,float commission, Efficiency efficiency) : base(id,name,lastname,age,experience,address,WorkerType)
        {
            this.Commission = commission;
            this.Efficiency = efficiency;
        }

        public override float EvaluateEmployee()
        {
            return (int)this.Efficiency * Experience;
        }

    }
}