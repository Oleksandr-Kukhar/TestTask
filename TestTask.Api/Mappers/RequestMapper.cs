using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Api.DTO;
using TestTask.Storage.Entities;

namespace TestTask.Api.Mappers
{
    public static class RequestMapper
    {
        public static Incident MapToIncident(this RequestDTO dto) => new()
        {
            Description = dto.Description
        };

        public static Account MapToAccount(this RequestDTO dto) => new()
        {
            Name = dto.AccountName
        };

        public static Contact MapToContact(this RequestDTO dto) => new()
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };
    }
}
