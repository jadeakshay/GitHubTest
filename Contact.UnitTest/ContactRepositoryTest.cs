using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contact.Core;
using Contact.Infrastructure;
using System.Data.Entity;
using System.Linq;

namespace Contact.UnitTest
{
    [TestClass]
    public class ContactRepositoryTest
    {
        ContactRepository Repo;

        // initialize the test class
        [TestInitialize]
        public void TestSetup()
        {
            ContactDbInitalize db = new ContactDbInitalize();
            Database.SetInitializer(db);
            Repo = new ContactRepository();
        }

        #region Contact  

        [TestMethod]
        public void IsRepositoryInitalizeWithValidNumberOfData_Contact()
        {
            var result = Repo.GetContacts();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(4, numberOfRecords);
        }

        [TestMethod]
        public void IsRepositoryAddsContact()
        {
            Contacts productToInsert = new Contacts
            {
                Contact_Id = 5,
                FirstName = "FirstName 005",
                LastName = "LastName 005",
                Email = "fname5.lname5@test.com",
                PhoneNumber = "020-12345678",
                Status = true

            };
            Repo.AddContact(productToInsert);            
            var result = Repo.GetContacts();
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(5, numberOfRecords);
        }
        #endregion
    }
}
