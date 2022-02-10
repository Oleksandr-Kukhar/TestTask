using System;
using System.Collections.Generic;

#nullable disable

namespace TestTask.Storage.Entities
{
    public partial class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
