using Models;
using Models.Dto;
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

        public List<Employee> GetSortedEmployees();

        public List<Employee> GetEmployeesByCity(string city);

        public int RemoveEmployee(Guid Id);

        public List<Employee> AddEmployees(List<EmployeeDto> employees);

        public float? EvaluateEmployee(Guid id);

        public List<EmployeeValueDto> GetEmployeesWithValue();

    }
}
