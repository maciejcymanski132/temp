using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models.Interfaces;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController :  Controller
    {
        private IEmployeesRepository _repository { get; set; }

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeesRepository provider)
        {
            _logger = logger;
            _repository = provider;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return this.Ok(_repository.GetAllEmployees());
        }

        [HttpGet("{employeeId:Guid}")]
        public IActionResult GetEmployee([FromRoute] Guid employeeId)
        {
            return this.Ok(_repository.GetEmployee(employeeId));
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
    }
}
