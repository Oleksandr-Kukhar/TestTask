using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Api.DTO;
using TestTask.Storage.Entities;

namespace TestTask.Api.Mappers
{
    public static class ContactMapper
    {
        public static Contact MapToEntity(this ContactCreateDTO contactCreate) => new()
        {
            FirstName = contactCreate.FirstName,
            LastName = contactCreate.LastName,
            Email = contactCreate.Email,
            AccountId = contactCreate.AccountId
        };
    }
}
