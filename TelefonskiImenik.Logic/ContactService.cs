using System.Collections.Generic;
using TelefonskiImenik.DataAccess;

namespace TelefonskiImenik.Logic
{
    public class ContactService(ContactRepository repository)
    {
        public List<Contact> GetAllContacts() => repository.GetAll();

        public List<Contact> SearchContacts(string query) => repository.Search(query);

        public void AddContact(Contact contact) => repository.Add(contact);
    }
}
