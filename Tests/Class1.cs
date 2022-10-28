using NUnit.Framework;
using DataAccess;
using DataService;
using Models;
using Models.Dto;
using Models.WorkerModels;
using System.Security.Cryptography.Xml;

namespace Tests
{
    [TestFixture]
    public class Test
    {
        public EmployeesRepository employeeRepository;
        public StationsRepository stationsRepository;
        public DataStorage dataStorage;

        [SetUp]
        public void SetUp()
        {
            this.dataStorage = new DataStorage();
            this.employeeRepository = new EmployeesRepository(this.dataStorage);
            this.stationsRepository = new StationsRepository(this.dataStorage);
        }


        [Test]
        public void Add_Physical_Worker_Success()
        {
            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.PhysicalWorker,
                15, null, null, null, null);
            this.employeeRepository.AddEmployees(new List<EmployeeDto>(){worker});
            Assert.AreEqual(this.employeeRepository.GetAllEmployees().Count(), 1);
            Assert.IsTrue(this.employeeRepository.GetAllEmployees().First().Name == "Test1");
        }

        [Test]
        public void Find_By_City_Success()
        {
            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.PhysicalWorker,
                15, null, null, null, null);
            this.employeeRepository.AddEmployees(new List<EmployeeDto>() { worker });
            var foundUser = this.employeeRepository.GetEmployeesByCity("Gdynia");
            Assert.AreEqual( this.employeeRepository.GetEmployeesByCity("Gdynia").Count(), 1);
            Assert.IsTrue(foundUser.FirstOrDefault()?.Name =="Test1");
        }

        [Test]
        public void Find_By_City_Failure()
        {
            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.PhysicalWorker,
                15, null, null, null, null);
            this.employeeRepository.AddEmployees(new List<EmployeeDto>() { worker });
            var foundUser = this.employeeRepository.GetEmployeesByCity("Gdynia");
            Assert.AreEqual(this.employeeRepository.GetEmployeesByCity("Łódź").Count(), 0);
        }


        [Test]
        public void Add_PhysicalWorker_WrongProperties_Throws()
        {
            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.PhysicalWorker,
                15, null, null, 115, null);
            Assert.Throws<ArgumentException>(() => this.employeeRepository.AddEmployees(new List<EmployeeDto>() { worker }));
        }

        [Test]
        public void Add_Trader_WrongProperties_Throws()
        {
            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.Trader,
                15, null, null, null, null);
            Assert.Throws<ArgumentException>(() => this.employeeRepository.AddEmployees(new List<EmployeeDto>(){worker}));
        }

        [Test]
        public void Add_Office_Worker_NotExistentStation_Throws()
        {
            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.OfficeWorker,
                null, null, null, 115, Guid.NewGuid());
            Assert.Throws<ArgumentException>(() => this.employeeRepository.AddEmployees(new List<EmployeeDto>() { worker }));
        }

        [Test]
        public void Add_Office_Worker_AvailableStation_Success()
        {
            this.stationsRepository.AddStation("Signature");
            var station = stationsRepository.GetAllStations().FirstOrDefault(s => s.Signature == "Signature");

            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.OfficeWorker,
                null, null, null, 115, station?.Id);
            var addedWorker = this.employeeRepository.AddEmployees(new List<EmployeeDto>() { worker });
            Assert.AreEqual(this.employeeRepository.GetAllEmployees().Count(), 1);
            Assert.AreEqual(this.stationsRepository.GetAllStations().First(s => s.Signature == "Signature").AssignedEmployee,addedWorker.First().Id);
        }

        [Test]
        public void Proper_OfficeWorker_Eval_Success()
        {
            this.stationsRepository.AddStation("Signature");
            var station = stationsRepository.GetAllStations().FirstOrDefault(s => s.Signature == "Signature");

            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.OfficeWorker,
                null, null, null, 115, station?.Id);
            var addedWorker = this.employeeRepository.AddEmployees(new List<EmployeeDto>() { worker });
            Assert.AreEqual((int?)this.employeeRepository.EvaluateEmployee(addedWorker.First().Id),1725);
        }

        [Test]
        public void Proper_PhysicalWorker_Eval_Success()
        {

            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.PhysicalWorker,
                130, null, null, null, null);
            var addedWorker = this.employeeRepository.AddEmployees(new List<EmployeeDto>() { worker });
            Assert.AreEqual((int?)this.employeeRepository.EvaluateEmployee(addedWorker.First().Id), 45);
        }

        [Test]
        public void Proper_Delete_PhysicalWorker_Success()
        {

            var worker = new EmployeeDto("Test1", "Test2", 33, 15, this.CreateTestAddress(), WorkerType.PhysicalWorker,
                130, null, null, null, null);
            var addedWorker = this.employeeRepository.AddEmployees(new List<EmployeeDto>() { worker });
            Assert.AreEqual(this.employeeRepository.GetAllEmployees().Count(),1);
            this.employeeRepository.RemoveEmployee(addedWorker.First().Id);
            Assert.AreEqual(this.employeeRepository.GetAllEmployees().Count(), 0);
        }

        public Address CreateTestAddress()
        {
            return new Address("15", "Rajska", "3", "Gdynia");
        }

    }
}