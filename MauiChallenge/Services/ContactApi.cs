using MauiChallenge.Helpers;
using MauiChallenge.Models;
using MauiChallenge.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiChallenge.Services
{
    public class ContactApi : IContactApi
    {
        private readonly HttpClient _httpClient;

        public ContactApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://randomuser.me/api/");
        }

        public async Task<List<ContactModel>> GetContacts(int page)
        {
            var response = await _httpClient.GetAsync($"?page={page}&results=10&seed=abc");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var contactResponse = JsonConvert.DeserializeObject<ContactResponseModel>(json);

                if (contactResponse != null && contactResponse.Contacts != null)
                {
                    return _proccessContacts(contactResponse.Contacts);
                }
                else
                {
                    throw new Exception("No contacts found.");
                }
            }
            else
            {
                throw new Exception("Failed to load contacts.");
            }
        }

        private List<ContactModel> _proccessContacts(List<ContactModel> contacts)
        {
            var ContactsList = new List<ContactModel>();
            foreach (var contact in contacts)
            {
                if (contact.Login?.Password != null)
                {
                    contact.Login.Password = PasswordHelper.Rot13Password(contact.Login.Password);
                }
                else
                {
                    contact.Login.Password = "No password available";
                }
                ContactsList.Add(contact);
            }
            return ContactsList;
        }
    }
}
