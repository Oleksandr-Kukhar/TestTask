using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Storage.Entities;

namespace TestTask.Storage.Storages
{
    public class ContactsStorage
    {
        private TestTaskDbContext _dbContext;

        public ContactsStorage (TestTaskDbContext context)
        {
            _dbContext = context;
        }
        public async Task<int> CreateContact(Contact contact)
        {
            var createdContact = (await _dbContext.Contacts.AddAsync(contact)).Entity;
            await _dbContext.SaveChangesAsync();
            return createdContact.Id;
        }
        public async Task DeleteContact(Contact contact)
        {
            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Contact> GetContactById(int id)
        {
            var result = await _dbContext.Contacts.FindAsync(id);
            return result;
        }
        public async Task UpdateContact(Contact contact)
        {
            _dbContext.Contacts.Update(contact);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Contact>> GetAllByAccountId(int accountId)
        {
            var results = await _dbContext.Contacts.Where(x => x.AccountId == accountId).ToListAsync();
            return results;
        }
        public async Task<Contact> GetContactByEmail(string email)
        {
            var result = await _dbContext.Contacts.FirstOrDefaultAsync(x => x.Email == email);
            return result;
        }
    }
}
