using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Storage.Entities;

namespace TestTask.Storage.Storages
{
    public class AccountsStorage
    {
        private TestTaskDbContext _dbContext;
        private ContactsStorage _contactsStorage;

        public AccountsStorage(TestTaskDbContext context, ContactsStorage contactsStorage)
        {
            _dbContext = context;
            _contactsStorage = contactsStorage;
        }
        public async Task<int> CreateAccount(Account account)
        {
            var createdAccount = (await _dbContext.Accounts.AddAsync(account)).Entity;
            await _dbContext.SaveChangesAsync();
            return createdAccount.Id;
        }
        public async Task DeleteAccount(Account contact)
        {
            _dbContext.Accounts.Remove(contact);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Account> GetAccountById(int id)
        {
            var result = await _dbContext.Accounts.FindAsync(id);
            return result;
        }
        public async Task<Account> GetAccountByName(string name)
        {
            var result = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Name == name);
            return result;
        }
        public async Task UpdateAccount(Account account)
        {
            var result = await _dbContext.Accounts.FindAsync(account.Id);
            result = account;
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Account>> GetAllByIncidentName(Guid incidentName)
        {
            var results = await _dbContext.Accounts.Where(x => x.IncidentName == incidentName).ToListAsync();
            return results;
        }
    }
}
