using Models;
using Models.WorkerModels;

namespace DataService
{
    public class DataStorage
    {
        public List<Employee> Employees;

        public List<OfficeStation> OfficeStations;

        public DataStorage()
        {
            this.Employees = new List<Employee>();
            this.OfficeStations = new List<OfficeStation>();
        }
    }
}
