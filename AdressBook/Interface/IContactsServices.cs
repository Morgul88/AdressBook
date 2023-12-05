using AdressBook.Models;

namespace AdressBook.Interface
{
    public interface IContactsServices
    {
        bool AddContact(IContacts contact);
        bool RemoveContact(string mail);
        void ViewAllContacts();
        void ViewOneContact(string mail);

        void SaveFile();
    }
}