using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Core.Interfaces
{
    public interface IContactsRepository
    {
        void AddContact(Contacts contact);
        void EditContact(Contacts contact);
        void DeleteContact(int contact_id);
        IEnumerable<Contacts> GetContacts();
        Contacts FindContactById(int Contact_Id);
    }
}
