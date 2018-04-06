using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Core;
using Contact.Core.Interfaces;

namespace Contact.Infrastructure
{
    public class ContactRepository : IContactsRepository
    {
        ContactContext context = new ContactContext();

        public void AddContact(Contacts contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
        }
        public void EditContact(Contacts contact)
        {
            context.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
        public Contacts FindContactById(int contact_id)
        {
            var c = (from r in context.Contacts where r.Contact_Id == contact_id select r).FirstOrDefault();
            return c;
        }
        public void DeleteContact(int contact_Id)
        {
            Contacts contact = context.Contacts.Find(contact_Id);
            context.Contacts.Remove(contact);
            context.SaveChanges();
        }
        public IEnumerable<Contacts> GetContacts()
        {
            return context.Contacts;
        }
    }
}
