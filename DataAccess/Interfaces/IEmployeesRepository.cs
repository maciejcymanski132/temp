using Models.Dto;
using Models.Interfaces;
using Models.WorkerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IEmployeesRepository
    {
        public IEnumerable<Employee> GetAllEmployees();

        public int RemoveEmployee(Guid Id);

        public Employee? AddEmployee(EmployeeDto employee);

        public int AddTrader(TraderDto employee);

        public int AddPsychicalWorker(PhysicalWorkerDto employee);

        public int AddOfficeWorker(OfficeWorkerDto employee);
    }
}
