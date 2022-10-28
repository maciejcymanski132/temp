using System.Net;
using AutoMapper;
using DataAccess;
using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dto;
using Models.WorkerModels;
using System.Text.Json;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;
using Microsoft.Graph;

namespace EmployeesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StationsComponent : Controller
    {
        private IStationsRepository _repository { get; set; }

        public StationsComponent( IStationsRepository repository)
        {
            _repository = repository;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<OfficeStation>))]
        public IActionResult GetStations()
        {
            return this.Ok(this._repository.GetAllStations());
        }

        [Microsoft.AspNetCore.Mvc.HttpPost("{signature}")]
        public IActionResult AddStation([FromRoute] string signature)
        {
            var response = this._repository.AddStation(signature);
            return this.Ok(response);
        }
    }
}
