using System;
using System.Collections.Generic;

#nullable disable

namespace TestTask.Storage.Entities
{
    public partial class Account
    {
        public Account()
        {
            Contacts = new HashSet<Contact>();
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public Guid? IncidentName { get; set; }

        public virtual Incident IncidentNameNavigation { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
