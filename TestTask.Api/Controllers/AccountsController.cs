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
[Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsStorage _accountsStorage;

        public AccountsController(AccountsStorage accountsStorage)
        {
            _accountsStorage = accountsStorage;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAccount([FromBody] AccountCreateDTO dto)
        {
            var accountId = await _accountsStorage.CreateAccount(dto.MapToEntity());
            return Ok(accountId);
        }
    }
}
