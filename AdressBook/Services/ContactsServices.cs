
using AdressBook.Interface;
using AdressBook.Models;
using System.Diagnostics;
using Newtonsoft.Json;

namespace AdressBook.Services;

public class ContactsServices : IContactsServices
{
    private readonly IFileService _fileService = new FileService(@"C:\Projects\AdressBook\content.json");
    public List<IContacts> _contactList = [];
    public static int _contactIdCounter = 1;

    public bool AddContact(Contacts contact)
    {
        try
        {
            _contactList.Add(contact);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
                // Lägg till andra inställningar om det behövs
            };

            _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList, settings));
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
    public IEnumerable<IContacts> GetContactsFromList()
    {
        try
        {
            //Hämtar info från min fil på datorn
            var content = _fileService.GetContentFromFile();
            //Om filen finns går jag in i if
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
            };
            if (!string.IsNullOrEmpty(content))
            {
                _contactList = JsonConvert.DeserializeObject<List<IContacts>>(content,settings)!;
                
                
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }

        // Om något går fel eller om det inte finns några kontakter returnerar vi en tom lista.
        return (IEnumerable<IContacts>)_contactList;
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
