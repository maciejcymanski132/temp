using AutoMapper;
using DataAccess;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dto;
using Models.Interfaces;
using Models.WorkerModels;
using System.Text.Json;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeesRepository _repository { get; set; }

        private readonly ILogger<EmployeeController> _logger;

        private IMapper _mapper;


        public EmployeeController(ILogger<EmployeeController> logger, IEmployeesRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var  options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return this.Ok(_repository.GetAllEmployees().Select(e => (object)e));
        }

        //[HttpGet("{employeeId:Guid}")]
        //public IActionResult GetEmployee([FromRoute] Guid employeeId)
        //{
        //    return this.Ok(_repository.GetEmployee(employeeId));
        //}

        [HttpDelete("{employeeId:Guid}")]
        public IActionResult RemoveEmployee([FromRoute] Guid employeeId)
        {
            var result = _repository.RemoveEmployee(employeeId);
            if (result < 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] EmployeeDto employee, WorkerType workerType)
        {

            var response = this._repository.AddEmployee(employee); Console.WriteLine(JsonSerializer.Serialize(employee));

            if (response is Employee)
            {
                return this.Ok(response);
            }

            return this.NotFound();
        }

        [HttpPost("PsychicalWorker")]
        public IActionResult AddPsychicalWorker([FromBody] PhysicalWorkerDto employee)
        {
            return this.Ok(this._repository.AddPsychicalWorker(employee));
        }

        [HttpPost("OfficeWorker")]
        public IActionResult AddOfficeWorker([FromBody] OfficeWorkerDto employee)
        {
            return this.Ok(this._repository.AddOfficeWorker(employee));
        }

        [HttpPost("Trader")]
        public IActionResult AddTrader([FromBody] TraderDto employee)
        {
            return this.Ok(this._repository.AddTrader(employee));
        }
    }
}
