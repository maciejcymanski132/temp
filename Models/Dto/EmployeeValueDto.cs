namespace Models.Dto
{
    public class EmployeeValueDto
    {

        public Guid Id;

        public string Name;

        public string LastName;

        public WorkerType WorkerType;

        public float EmployeeValue;


        public EmployeeValueDto(Guid id, string name, string lastname, WorkerType workertype, float value)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastname;
            this.WorkerType = workertype;
            this.EmployeeValue = value;
        }

    }
}
