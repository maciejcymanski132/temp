using System.ComponentModel.DataAnnotations;

namespace Models.WorkerModels
{

    public class OfficeWorker : Employee
    {

        [Required]
        public Guid OfficeStation { get; set; }

        [Range(70,150)]
        public int Intelligence { get; set; }

        public OfficeWorker(Guid id, string name, string lastname, int age, float experience, Address address, WorkerType WorkerType, int intelligence, Guid officeStation) : base(id, name, lastname, age, experience, address, WorkerType)
        {
            this.Intelligence = intelligence;
            this.OfficeStation = officeStation;
        }

        public override float EvaluateEmployee()
        {
            return Intelligence * Experience;
        }

    }
}
