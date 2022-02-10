using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Api.DTO;
using TestTask.Storage.Entities;

namespace TestTask.Api.Mappers
{
    public static class AccountMapper
    {
        public static Account MapToEntity(this AccountCreateDTO accountCreate) => new()
        {
            Name = accountCreate.Name
        };

    }
}
