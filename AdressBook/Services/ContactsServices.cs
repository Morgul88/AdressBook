
using AdressBook.Interface;
using AdressBook.Models;
using System.ComponentModel.Design;


namespace AdressBook.Services;

public class ContactsServices : IContactsServices
{
    private static readonly List<IContacts> _contactList = [];
    public static int _contactIdCounter = 1;

    public bool AddContact(IContacts contact)
    {
        if (_contactList != null)
        {
            _contactList.Add(contact);
            return true;
        }
        else
            return false;
    }
    public void Savefile()
    {

    }
    public bool RemoveContact(string mail)
    {
        var findContact = _contactList.Find(x => x.Email == mail.Trim());
        if (findContact != null)
        {
            _contactList.Remove(findContact!);
            return true;
        }
        else
            return false;
            
            
    }

    public void ViewAllContacts()
    {
        foreach (var contact in _contactList)
        {
            Console.WriteLine($" Id number: #{contact.Id}");
            Console.WriteLine($"Name: {contact.FirstName}");
            Console.WriteLine($"Phone:{contact.PhoneNumber}");
            Console.WriteLine($"Adress: {contact.HomeAdress}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }

    public void ViewOneContact(string mail)
    {
        var findContact = _contactList.Find(x => x.Email == mail.Trim()); ;
        if (findContact != null)
        {
            Console.WriteLine($"Name: {findContact.FirstName}");
            Console.WriteLine($"Phone :{findContact.PhoneNumber}");
            Console.WriteLine($"Adress: {findContact.HomeAdress}");
            Console.WriteLine($"Email: {findContact.Email}");
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
}
