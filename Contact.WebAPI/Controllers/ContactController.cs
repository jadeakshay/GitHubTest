using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Contact.Core;
using Contact.Infrastructure;

namespace Contact.WebAPI.Controllers
{
    public class ContactController : ApiController
    {
        private ContactRepository db = new ContactRepository();

        //// GET: api/Contact
        // we can fetch data as XML file via http://localhost:13793/api/Contact URL
        public IEnumerable<Contacts> GetContacts()
        {
            // Calling the Reopsitory project GetContacts method
            return db.GetContacts();
        }

        // GET: api/Contact/5
        // we can fetch data as XML file via http://localhost:13793/api/Contact/{id} URL 
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult GetContact(int id)
        {
            // Calling the Reopsitory project FindContactsById method
            Contacts Contacts = db.FindContactById(id);
            if (Contacts == null)
            {
                return NotFound();
            }

            return Ok(Contacts);
        }


        //// PUT: api/Contact/5
        // we can perform edit Contacts method
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContact(int id, Contacts Contacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Contacts.Contact_Id)
            {
                return BadRequest();
            }
            // Calling the Reopsitory project EditContacts method
            db.EditContact(Contacts);

            return StatusCode(HttpStatusCode.NoContent);
        }

        //// POST: api/Contact/
        // we can perform add Contacts method
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult PostContact(Contacts Contacts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Calling the Reopsitory project AddContacts method
            db.AddContact(Contacts);

            return CreatedAtRoute("DefaultApi", new { id = Contacts.Contact_Id }, Contacts);
        }

        //// DELETE: api/Contact/5
        // we can perform delete Contacts method
        [ResponseType(typeof(Contacts))]
        public IHttpActionResult DeleteContact(int id)
        {
            Contacts Contacts = db.FindContactById(id);
            if (Contacts == null)
            {
                return NotFound();
            }
            // Calling the Reopsitory project RemoveContacts method
            db.DeleteContact(id);

            return Ok(Contacts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }        
    }
}
