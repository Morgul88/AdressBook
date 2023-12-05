
using AdressBook.Interface;


namespace AdressBook.Services;

public class ContactsServices : IContactsServices
{
    private static readonly List<IContacts> _contactList = [];
    int count = 0;
    
    public void AddContact(IContacts contact)
    {
        count++;
        Console.Write(count); _contactList.Add(contact); 
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
            Console.WriteLine($"Name: {contact.FirstName}");
            Console.WriteLine($"Phone :{contact.PhoneNumber}");
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
