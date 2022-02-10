using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Api.DTO;
using TestTask.Api.Mappers;
using TestTask.Storage.Storages;

namespace TestTask.Api.Controllers
{
    [Route("api/incidents")]
    public class IncidentsController : ControllerBase
    {
        private readonly IncidentsStorage _incidentsStorage;

        public IncidentsController(IncidentsStorage incidentsStorage)
        {
            _incidentsStorage = incidentsStorage;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddIncident([FromBody] IncidentCreateDTO dto)
        {
            var incidentName = await _incidentsStorage.CreateIncident(dto.MapToEntity());
            return Ok(incidentName);
        }
    }
}
