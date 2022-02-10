using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Storage.Entities;

namespace TestTask.Storage.Storages
{
    public class IncidentsStorage
    {
        private TestTaskDbContext _dbContext;
        private AccountsStorage _accountsStorage;

        public IncidentsStorage(TestTaskDbContext context, AccountsStorage accountsStorage)
        {
            _dbContext = context;
            _accountsStorage = accountsStorage;
        }
        public async Task<Guid> CreateIncident(Incident incident)
        {
            var createdIncident = (await _dbContext.Incidents.AddAsync(incident)).Entity;
            await _dbContext.SaveChangesAsync();
            return createdIncident.Name;
        }
        public async Task DeleteIncident(Incident incident)
        {
            _dbContext.Incidents.Remove(incident);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Incident> GetIncidentById(Guid incidentId)
        {
            var result = await _dbContext.Incidents.FindAsync(incidentId);
            return result;
        }
        public async Task UpdateIncident(Incident incident)
        {
            var result = await _dbContext.Incidents.FindAsync(incident.Name);
            result = incident;
            await _dbContext.SaveChangesAsync();
        }
    }
}
