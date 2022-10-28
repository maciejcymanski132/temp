using DataAccess.Interfaces;
using DataProvider;
using Models;
using Models.Dto;
using Models.WorkerModels;

namespace DataService
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private IDataStorage _storage { get; set; }
        private readonly EmployeeValidator _validator = new();

        public EmployeesRepository(IDataStorage storage)
        {
            this._storage = storage;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return this._storage.GetEmployees();
        }

        public List<Employee> GetSortedEmployees()
        {
            return this._storage.GetEmployees().OrderByDescending(x => x.Experience).ThenBy(x => x.Age).ThenBy(x => x.LastName).ToList();
        }

        public List<Employee> GetEmployeesByCity(string city)
        {
            return this._storage.GetEmployees().Where(e => e.Address.City.ToLower().Equals(city.ToLower())).ToList();
        }

        public List<EmployeeValueDto> GetEmployeesWithValue()
        {
            return this._storage.GetEmployees().Select(e => new EmployeeValueDto(e.Id, e.Name, e.LastName, e.WorkerType, e.EvaluateEmployee())).ToList();
        }

        public float? EvaluateEmployee(Guid id)
        {
            try
            {
                var value = this._storage.GetEmployees().First(e => e.Id == id).EvaluateEmployee();
                return value;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int RemoveEmployee(Guid id)
        {
            var employee = this._storage.GetEmployees().FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                this._storage.GetEmployees().Remove(employee);
                return 1;
            }
            return 0;
        }

        public List<Employee> AddEmployees(List<EmployeeDto> employees)
        {
            List<Employee> workers = new List<Employee>();

            foreach(var employee in employees)
            {
                this._validator.ValidateEmployee(employee,this._storage.GetStations());

                switch (employee.WorkerType)
                {
                    case WorkerType.OfficeWorker:
                        var worker = new OfficeWorker(Guid.NewGuid(), employee.Name, employee.LastName, employee.Age, employee.Experience, employee.Address, employee.WorkerType, (int)employee.Intelligence, (Guid)employee.OfficeStation);
                        var station = this._storage.GetStations().First(s => s.Id == employee.OfficeStation);
                        station.AssignedEmployee = worker.Id;
                        workers.Add(worker);
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

            if(workers.Any(w => this._storage.GetEmployees().Select(e => e.Id).Contains(w.Id)))
            {
                throw new ArgumentException("Id of worker is not unique");
            }

            this._storage.GetEmployees().AddRange(workers);

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
