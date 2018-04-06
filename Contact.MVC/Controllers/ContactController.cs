using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Mvc;
using Contact.Core;
using Contact.Infrastructure;
using Contact.MVC.Models;

namespace Contact.MVC.Controllers
{
    public class ContactController : Controller
    {
        private string CONTACT_URI = "http://localhost:53171/api/Contact";
        public ActionResult Index()
        {
            
            ContactClient cc = new ContactClient();
            ViewBag.listContacts = cc.GetAllContacts();
            return View();
        }
        public ActionResult Create()
        {
            ContactClient cc = new ContactClient();
            return View();
        }
        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                ContactClient cc = new ContactClient();
                cc.AddContact(contact);
                return RedirectToAction("Index", "Contact");
            }
            return View("Create");
        }


        // GET: Contact/Delete
        public ActionResult Delete(int id)
        {
            ContactClient cc = new ContactClient();
            cc.DeleteContact(id);
            return RedirectToAction("Index", "Contact");
        }

        // GET: Contact/Edit
        [HttpGet]
        public ActionResult GoDelete(int id)
        {
            ContactClient cc = new ContactClient();
            Contacts contact = new Contacts();
            contact = cc.GetContact(id);
            return View("Delete", contact);
        }

        // GET: Contact/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ContactClient cc = new ContactClient();
            Contacts contact = new Contacts();
            contact = cc.GetContact(id);
            return View("Edit", contact);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ContactClient cc = new ContactClient();
            Contacts contact = new Contacts();
            contact = cc.GetContact(id);
            return View("Details", contact);
        }

        // POST: Contact/Edit
        [HttpPost]
        public ActionResult Edit(Contacts contact)
        {
            if (ModelState.IsValid)
            {
                ContactClient cc = new ContactClient();
                cc.EditContact(contact);
                return RedirectToAction("Index", "Contact");
            }
            return View("Edit");
        }
    }
}