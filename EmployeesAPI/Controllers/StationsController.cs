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
    public class StationsComponent : Controller
    {
        private IEmployeesRepository _repository { get; set; }

        private readonly ILogger<EmployeeController> _logger;

        public StationsComponent(ILogger<EmployeeController> logger, IEmployeesRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetStations()
        {
            return this.Ok(this._repository.GetAllStations());
        }

        [HttpPost]
        public IActionResult AddStation() { return this.Ok(); }
    }
}
