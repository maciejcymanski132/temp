
namespace Models.WorkerModels
{
    public interface IEmployee
    {
        Address Address { get; set; }
        int Age { get; set; }
        float Experience { get; set; }
        Guid Id { get; set; }
        string LastName { get; set; }
        string Name { get; set; }
        WorkerType WorkerType { get; set; }

        float EvaluateEmployee();
    }
}