
using AdressBook.Interface;
using System.Diagnostics;
using Newtonsoft.Json;
using AdressBook.Models;

namespace AdressBook.Services;


public class ContactsServices : IContactsServices
{
    // En privat instansvariabel för att använda IFileService-gränssnittet
    private readonly IFileService _fileService = new FileService(@"C:\Projects\AdressBook\content.json");

    // En lista som innehåller kontakter (implementerar IContacts-gränssnittet)
    public List<IContacts> _contactList = [];

    // En statisk variabel för att hålla reda på kontakt-ID
    public static int _contactIdCounter = 1;

    public bool AddContact(Contacts contact)
    {
        try
        {
            // Hämtar befintliga kontakter från filen
            List<IContacts> contacts = GetContactsFromList();

            // Lägger till den nya kontakten i listan
            _contactList.Add(contact);

            // Ställer in inställningar för att hantera typer automatiskt
            var settings = new JsonSerializerSettings
            {
                //Skriver in inställning på objektet
                TypeNameHandling = TypeNameHandling.Auto
                
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
            _contactList.Remove(findContact);

            var settings = new JsonSerializerSettings
            {
                //Skriver in inställning på objektet
                TypeNameHandling = TypeNameHandling.Auto

            };

            _fileService.SaveContentToFile(JsonConvert.SerializeObject(_contactList, settings));
            return true;
            
        }
        else
            return false;
    }
    public List<IContacts> GetContactsFromList()
    {
        try
        {
            //Hämtar info från min fil på datorn
            var content = _fileService.GetContentFromFile();
            
            var settings = new JsonSerializerSettings
            {
                //Ställer in inställningar för type
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented,
            };
            //Om filen finns går jag in i if
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
