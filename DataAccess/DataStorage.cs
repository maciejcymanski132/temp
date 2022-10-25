using Models;
using Models.Interfaces;
using Models.WorkerModels;

namespace DataService
{
    public class DataStorage
    {
        public ICollection<Employee> Employees;

        public ICollection<OfficeStation> OfficeStations;

        public DataStorage()
        {
            this.Employees = new List<Employee>();
            this.OfficeStations = new List<OfficeStation>();
        }
    }
}
