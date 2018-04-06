using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contact.Core;
using Contact.Infrastructure;
using Contact.WebAPI;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

namespace Contact.MVC.Models
{    
    public class ContactClient
    {
        private string CONTACT_URI = "http://localhost:53171/api/Contact";

        //Get All Contacts
        public IEnumerable<Contacts> GetAllContacts()
        {
            try
            {
                HttpClient client = GetClient();
                client.BaseAddress = new Uri(CONTACT_URI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Contact").Result;
                if (response.IsSuccessStatusCode)
                {
                    var contactJsonString = response.Content.ReadAsStringAsync().Result;
                    var deserialized = JsonConvert.DeserializeObject<IEnumerable<Contacts>>(contactJsonString);
                    if (deserialized != null)
                        return deserialized;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        //Get All Contacts
        public Contacts GetContact(int id)
        {
            try
            {
                HttpClient client = GetClient();
                client.BaseAddress = new Uri(CONTACT_URI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("Contact/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    var contactJsonString = response.Content.ReadAsStringAsync().Result;
                    var deserialized = JsonConvert.DeserializeObject<Contacts>(contactJsonString);
                    if (deserialized != null)
                        return deserialized;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        // Create a Contact
        public bool AddContact(Contacts contact)
        {
            try
            {
                HttpClient client = GetClient();
                client.BaseAddress = new Uri(CONTACT_URI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync("Contact/", new StringContent(
   JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Delete a Contact
        public bool DeleteContact(int id)
        {
            try
            {
                HttpClient client = GetClient();
                client.BaseAddress = new Uri(CONTACT_URI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("Contact/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Edit a Contact
        public bool EditContact(Contacts contact)
        {
            try
            {
                HttpClient client = GetClient();
                client.BaseAddress = new Uri(CONTACT_URI);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsync("Contact/" + contact.Contact_Id, new StringContent(
   JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json")).Result;
               
                if (response.IsSuccessStatusCode)
                {
                    return response.IsSuccessStatusCode;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private static HttpClient GetClient()
        {
            return new HttpClient();
        }
    }
}