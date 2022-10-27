using AutoMapper;
using DataAccess;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dto;
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

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeesRepository repository)
        {
            _logger = logger;
            _repository = repository;
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

       [HttpGet("sortedEmployees")]
       public IActionResult GetSortedEmployees()
        {
            return this.Ok(_repository.GetSortedEmployees());
        }

        [HttpGet("employeesByCity/{city}")]
        public IActionResult GetEmployeesByCity([FromRoute] string city)
        {
            var result = this._repository.GetEmployeesByCity(city);
            if (result.Count > 0)
            {
                return this.Ok(result);
            }
            return this.NotFound($"No employees in {city}");
        }

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
        public IActionResult AddEmployees([FromBody] List<EmployeeDto> employees)
        {

            var response = this._repository.AddEmployees(employees);

            if (response is IEnumerable<Employee>)
            {
                return this.Ok(response);
            }

            return this.NotFound();
        }

        [HttpGet("evaluate/{employeeId:Guid}")]
        public IActionResult EvaluateEmployee([FromRoute] Guid employeeId)
        {
            var response = _repository.EvaluateEmployee(employeeId);
            if (response != null)
            {
                return this.Ok(response);
            }
            return this.NotFound("No employee with such id");
        } 

    }
}
