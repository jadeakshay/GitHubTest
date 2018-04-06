using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Contact.Core;

namespace Contact.Infrastructure
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("name=contactappconnectionstring") // Connection String
        {
            Database.SetInitializer(new ContactDbInitalize());
        }
        // Tables goin to create in Database
        public DbSet<Contacts> Contacts { get; set; }

    }
}
