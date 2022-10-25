using AutoMapper;
using DataAccess.Interfaces;
using DataProvider;
using Models;
using Models.Dto;
using Models.Interfaces;
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

        public IMapper mapper;

        public EmployeesRepository(IMapper mapper)
        {
            this.storage = new DataStorage();
            this.mapper = mapper;
        }

        public IEnumerable<OfficeStation> GetAllStations()
        {
            return this.storage.OfficeStations;
        }


        public IEnumerable<Employee> GetAllEmployees()
        {
            return this.storage.Employees;
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

        public Employee? AddEmployee(EmployeeDto employee)
        {
            Employee worker;
            Console.WriteLine("wtf");
            var isValid = this._validator.ValidateEmployee(employee);

            switch (employee.WorkerType)
            {
                case WorkerType.OfficeWorker:
                    worker = new OfficeWorker(employee.Id, employee.Name, employee.LastName,employee.Age, employee.Experience, employee.Address, employee.WorkerType, (int)employee.Intelligence, (Guid)employee.OfficeStation);
                    break;
                case WorkerType.PhysicalWorker:
                    worker = new PhysicalWorker(employee.Id, employee.Name, employee.LastName, employee.Age, employee.Experience, employee.Address, employee.WorkerType, (int)employee.Strength); 
                    break;
                case WorkerType.Merchant:
                    worker = new Trader(employee.Id, employee.Name, employee.LastName, employee.Age, employee.Experience, employee.Address, employee.WorkerType, (float)employee.Commission, this.CalculateEfficiency((int)employee.Efficiency));
                    break;
                default:
                    throw new ArgumentException("Invalid worker type");
            }
            this.storage.Employees.Add(worker);
            return worker;

        }

        public int AddTrader(TraderDto employee)
        {
            storage.Employees.Add(this.mapper.Map<Trader>(employee));
            return 1;
        }

        public int AddPsychicalWorker(PhysicalWorkerDto employee)
        {
            storage.Employees.Add(this.mapper.Map<PhysicalWorker>(employee));
            return 1;
        }

        public int AddOfficeWorker(OfficeWorkerDto employee)
        {
            storage.Employees.Add(this.mapper.Map<OfficeWorker>(employee));
            return 1;
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
