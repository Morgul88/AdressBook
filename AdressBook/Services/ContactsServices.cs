
using AdressBook.Interface;
using AdressBook.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace AdressBook.Services;

public class ContactsServices : IContactsServices
{
    private readonly IFileService _fileService = new FileService(@"C:\Projects\AdressBook\content.json");
    public List<Contacts> _contactList = [];
    public static int _contactIdCounter = 1;

    public bool AddContact(Contacts contact)
    {
        try
        {
            _contactList.Add(contact);
            _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList));
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return false;
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
    public IEnumerable<Contacts> GetContactsFromList()
    {
        try
        {
            var content = _fileService.GetContentFromFile();
            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<List<Contacts>>(content)!;

                
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        // Om något går fel eller om det inte finns några kontakter returnerar vi en tom lista.
        return _contactList;
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
