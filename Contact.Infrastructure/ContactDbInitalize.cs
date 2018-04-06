using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Core;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Contact.Infrastructure
{
    public class ContactDbInitalize : DropCreateDatabaseIfModelChanges<ContactContext>
    {
        protected override void Seed(ContactContext context)
        {
            context.Contacts.Add(
                    new Contacts
                    {
                        Contact_Id = 1,
                        FirstName = "FirstName 001",
                        LastName = "LastName 001",
                        Email = "fname1.lname1@test.com",
                        PhoneNumber = "020-12345678",
                        Status = true
                    }
             );

            context.Contacts.Add(
                    new Contacts
                    {
                        Contact_Id = 2,
                        FirstName = "FirstName 002",
                        LastName = "LastName 002",
                        Email = "fname2.lname2@test.com",
                        PhoneNumber = "020-12345678",
                        Status = true
                    }
             );

            context.Contacts.Add(
                    new Contacts
                    {
                        Contact_Id = 3,
                        FirstName = "FirstName 003",
                        LastName = "LastName 003",
                        Email = "fname3.lname3@test.com",
                        PhoneNumber = "020-12345678",
                        Status = true
                    }
             );

            context.Contacts.Add(
                   new Contacts
                   {
                       Contact_Id = 4,
                       FirstName = "FirstName 004",
                       LastName = "LastName 004",
                       Email = "fname4.lname4@test.com",
                       PhoneNumber = "020-23456789",
                       Status = true
                   }
               );

            context.SaveChanges();
            base.Seed(context);
        }
    }
}
