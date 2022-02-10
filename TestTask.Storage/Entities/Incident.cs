using System;
using System.Collections.Generic;

#nullable disable

namespace TestTask.Storage.Entities
{
    public partial class Incident
    {
        public Incident()
        {
            Accounts = new HashSet<Account>();
        }

        public Guid Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
