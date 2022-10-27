using AutoMapper;
using DataAccess.Interfaces;
using DataProvider;
using Models;
using Models.Dto;
using Models.WorkerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DataService
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public DataStorage storage { get; set; }
        public EmployeeValidator _validator = new EmployeeValidator();

        public EmployeesRepository()
        {
            this.storage = new DataStorage();
        }

        public List<OfficeStation> GetAllStations()
        {
            return this.storage.OfficeStations;
        }


        public IEnumerable<Employee> GetAllEmployees()
        {
            return this.storage.Employees;
        }

        public List<Employee> GetSortedEmployees()
        {
            return this.storage.Employees.OrderByDescending(x => x.Experience).ThenBy(x => x.Age).ThenBy(x => x.LastName).ToList();
        }

        public List<Employee> GetEmployeesByCity(string city)
        {
            return this.storage.Employees.Where(e => e.Address.City.ToLower().Equals(city.ToLower())).ToList();
        }

        public float? EvaluateEmployee(Guid id)
        {
            try
            {
                var value = this.storage.Employees.Where(e => e.Id == id).First().EvaluateEmployee();
                return value;
            }
            catch (Exception ex)
            {
                return null;
            }
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

        public List<Employee?> AddEmployees(List<EmployeeDto> employees)
        {
            List<Employee> workers = new List<Employee>();

            foreach(var employee in employees)
            {
                Console.Write(employee.Address.City);
                this._validator.ValidateEmployee(employee);

                switch (employee.WorkerType)
                {
                    case WorkerType.OfficeWorker:
                        workers.Add(new OfficeWorker(Guid.NewGuid(), employee.Name, employee.LastName, employee.Age, employee.Experience, employee.Address, employee.WorkerType, (int)employee.Intelligence, (Guid)employee.OfficeStation));
                        break;
                    case WorkerType.PhysicalWorker:
                        workers.Add(new PhysicalWorker(Guid.NewGuid(), employee.Name, employee.LastName, employee.Age, employee.Experience, employee.Address, employee.WorkerType, (int)employee.Strength));
                        break;
                    case WorkerType.Trader:
                        workers.Add(new Trader(Guid.NewGuid(), employee.Name, employee.LastName, employee.Age, employee.Experience, employee.Address, employee.WorkerType, (float)employee.Commission, this.CalculateEfficiency((int)employee.Efficiency)));
                        break;
                    default:
                        throw new ArgumentException("Invalid worker type");
                }
            }

            if(workers.Any(w => this.storage.Employees.Select(e => e.Id).Contains(w.Id)))
            {
                throw new ArgumentException("Id of worker is not unique");
            }

            this.storage.Employees.AddRange(workers);

            return workers;
        }


        public Efficiency CalculateEfficiency(int efficiency)
        {
            if (efficiency > 0 && efficiency < 60)
            {
                return Efficiency.Low;
            }
            if(efficiency >= 60 && efficiency < 90)
            {
                return Efficiency.Medium;
            }
            if(efficiency >= 90 && efficiency <= 120)
            {
                return Efficiency.High;
            }
            throw new ArgumentException("Efficiency out of scale");
        }

    }
}
