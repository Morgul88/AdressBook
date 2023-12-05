using AdressBook.Models;

namespace AdressBook.Interface
{
    public interface IContactsServices
    {
        void AddContact(IContacts contact);
        bool RemoveContact(string mail);
        void ViewAllContacts();
        void ViewOneContact(string mail);
    }
}