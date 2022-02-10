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
    [Route("api/task")]
    public class RequestController : ControllerBase
    {
        private readonly IncidentsStorage _incidentsStorage;
        private readonly ContactsStorage _contactsStorage;
        private readonly AccountsStorage _accountsStorage;

        public RequestController(
            IncidentsStorage incidentsStorage,
            ContactsStorage contactsStorage,
            AccountsStorage accountsStorage)
        {
            _incidentsStorage = incidentsStorage;
            _contactsStorage = contactsStorage;
            _accountsStorage = accountsStorage;
        }

        [HttpPost("request")]
        public async Task<IActionResult> AddAccount([FromBody] RequestDTO dto)
        {
            var account = await _accountsStorage.GetAccountByName(dto.AccountName);
            if (account is null)
            {
                return NotFound();
            }

            var contact = await _contactsStorage.GetContactByEmail(dto.Email);
            if (contact is null)
            {
                contact = dto.MapToContact();
                contact.AccountId = account.Id;
                await _contactsStorage.CreateContact(contact);
            }
            else
            {
                contact.FirstName = dto.FirstName;
                contact.LastName = dto.LastName;
                contact.AccountId = account.Id;
                await _contactsStorage.UpdateContact(contact);
            }

            var incidentName = await _incidentsStorage.CreateIncident(dto.MapToIncident());
            account.IncidentName = incidentName;
            await _accountsStorage.UpdateAccount(account);

            return Ok();
        }
    }
}
