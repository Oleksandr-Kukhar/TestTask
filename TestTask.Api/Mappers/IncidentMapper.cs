using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Api.DTO;
using TestTask.Storage.Entities;

namespace TestTask.Api.Mappers
{
    public static class IncidentMapper
    {
        public static Incident MapToEntity(this IncidentCreateDTO incidentCreate) => new()
        {
            Description = incidentCreate.Description
        };
    }
}
