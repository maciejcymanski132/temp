using DataAccess.Interfaces;
using DataProvider;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public DataStorage storage { get; set; }
        public EmployeeValidator _validator { get; set; }

        public EmployeesRepository()
        {
            this.storage = new DataStorage();
        }

        public IEnumerable<IEmployee> GetAllEmployees()
        {
            return this.storage.Employees;
        }

        public IEmployee? GetEmployee(Guid Id)
        {
            return this.storage.Employees.FirstOrDefault(e => e.Id == Id);
        }

        public int RemoveEmployee(Guid id)
        {
            var employee = this.storage.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                this.storage.Employees.Remove(employee);
                return 1;
            }
            return 0;
        }

        public int AddEmployee(IEmployee employee)
        {
            _validator.ValidateEmployee(employee);

        }

        public IEmployee CreateEmployee(IEmployee employee)
        {
            switch (employee.WorkerType)
            {
                case (WorkerType.OfficeWorker):
                {
                    storage.Employees.Add(employee);
                    break;
                }
                case (WorkerType.PhysicalWorker):
                {
                    storage.Employees.Add(employee);
                    break;
                }
                case (WorkerType.Merchant):
                {
                    storage.Employees.Add(employee);
                    break;
                }
            }
        }
    }
}
