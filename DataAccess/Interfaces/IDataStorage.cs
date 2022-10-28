using Models.WorkerModels;
using Models;
using System;
namespace DataAccess.Interfaces
{
    public interface IDataStorage
    {
        public List<Employee> GetEmployees();

        public List<OfficeStation> GetStations();

    }
}
