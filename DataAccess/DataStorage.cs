using DataAccess.Interfaces;
using Models;
using Models.WorkerModels;

namespace DataService
{
    public class DataStorage : IDataStorage
    {
        private List<Employee> _employees;

        private List<OfficeStation> _officeStations;

        public DataStorage()
        {
            this._officeStations = new List<OfficeStation>();

            this._employees = new List<Employee>()
            {
                //new Trader(Guid.NewGuid(), "Bartosz","Kowalski",25,10,new Address("15","Rajska","4","Gdynia"),WorkerType.Trader,30,Efficiency.Medium),
                //new PhysicalWorker(Guid.NewGuid(), "Arkadiusz","Milewski",33,5,new Address("15","Rajska","4","Gdynia"),WorkerType.PhysicalWorker,66),
            };
        }

        public List<Employee> GetEmployees()
        {
            return this._employees;
        }

        public List<OfficeStation> GetStations()
        {
            return this._officeStations;
        }
    }
}
