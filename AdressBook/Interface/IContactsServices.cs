using AdressBook.Models;

namespace AdressBook.Interface
{
    public interface IContactsServices
    {
        bool AddContact(Contacts contact);
        bool RemoveContact(string mail);
       
        void ViewOneContact(string mail);

        IEnumerable<IContacts> GetContactsFromList();
    }
}