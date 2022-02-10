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
[Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsStorage _contactsStorage;

        public ContactsController(ContactsStorage contactsStorage)
        {
            _contactsStorage = contactsStorage;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAccount([FromBody] ContactCreateDTO dto)
        {
            var contactId = await _contactsStorage.CreateContact(dto.MapToEntity());
            return Ok(contactId);
        }

    }
}
