
using AdressBook.Interface;
using AdressBook.Models;

namespace AdressBook.Services;
public class MenuServices : IMenuServices
{
    private readonly IContactsServices _contactsServices = new ContactsServices();

    public void ShowMainMenu()
    {
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("  ### WELCOME TO YOUR CONTACTS ###");
            Console.WriteLine();
            Display("Main Menu:");
            Console.WriteLine(" 1. ADD TO CONTACTS");
            Console.WriteLine();
            Console.WriteLine(" 2. VIEW CONTACTS");
            Console.WriteLine();
            Console.WriteLine(" 3  VIEW CONTACT");
            Console.WriteLine();
            Console.WriteLine(" 4. LOAD YOUR BOOK FROM COMP");
            Console.WriteLine();
            Console.WriteLine(" 5. REMOVE CONTACT");
            Console.WriteLine();
            Console.WriteLine(" 6. SAVE BOOK TO COMP");
            Console.WriteLine();
            Console.WriteLine(" 0. EXIT");
            Console.WriteLine();    
            Console.Write("What would you like to do? :");
            var answer = Console.ReadLine();  
            
            switch(answer) 
            {
                case "1": 
                    ShowAddMenu();
                    break;

                case "2":
                    ShowAllUsersMenu();
                    break;

                 case "3":
                    ShowOneUserMenu();
                    break;

                case "4":
                    ShowAllUsersFromCompMenu();
                    break;

                case "5":
                    ShowRemoveContactMenu();                   
                    break;

                case "6":
                    ShowSaveMenu();
                    break;
                
                case "0":
                    ExitApplication();
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;     
            }
        }
    }
    public void ShowSaveMenu()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to save? This will overwrite last saved adressbook?");
        Console.WriteLine("y/n?");
        var answer = Console.ReadLine()!.ToLower();
        if(answer == "y")
        {
            bool result = _contactsServices.SaveListToFile();
            if (result)
            {
                Console.WriteLine("File saved.");
            }
        }
        Console.ReadLine();
    }
    public void ShowAddMenu()
    {
        Contacts contacts = new Contacts();
        

        Console.Clear();
        Display("Add Menu");
        
        Console.WriteLine();
        Console.WriteLine("First Name:");
        contacts.FirstName = Console.ReadLine()!;
        Console.WriteLine("PhoneNumber:");
        contacts.PhoneNumber = Console.ReadLine()!;
        Console.WriteLine("Email:");
        contacts.Email = Console.ReadLine()!;
        Console.WriteLine("Adress:");
        contacts.HomeAdress = Console.ReadLine()!;
        
        if (_contactsServices.AddContact(contacts))
        {
            Console.WriteLine("Contact has been added.");
        }
        else
        {
            Console.WriteLine("Something went wrong. Plz try again !");
        }
        Console.ReadKey();
    }
    private void ShowAllUsersFromCompMenu()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to load? If you dont save first your list will be lost");
        Console.WriteLine();
        Console.WriteLine("y/n?");
        var answer = Console.ReadLine()!.ToLower();
        if (answer == "y")
        {

            Console.Clear();
            Display("CONTACTS:");

            List<IContacts> contacts = _contactsServices.GetContactsFromComp();
            if (contacts.Count > 0)
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Id: {contact.Id}");
                    Console.WriteLine($"FirstName: {contact.FirstName}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"HomeAdress: {contact.HomeAdress}");
                    Console.WriteLine("-----------------------------------");
                }
            }
            else
            {
                Console.WriteLine("The list is empty. Press any button to continue..");
            }


            Console.ReadKey();
        }
    }

    private void ShowAllUsersMenu()
    {
        Console.Clear();
        Display("CONTACTS:");

        var list = _contactsServices.GetContactsFromList();
        if (list.Count > 0)
        {
            foreach (var contact in list)
            {
                Console.WriteLine($"Id: {contact.Id}");
                Console.WriteLine($"FirstName: {contact.FirstName}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"HomeAdress: {contact.HomeAdress}");
                Console.WriteLine("-----------------------------------");
            }
        }
        else
        {
            Console.WriteLine("The list is empty. Press any button to continue..");
        }


        Console.ReadKey();
    }

    private void ShowOneUserMenu()
    {
        Console.Clear();
        Display("CONTACT");
        Console.WriteLine("Insert email: ");
        var answer = Console.ReadLine()!;
        Console.Clear();
        Display("CONTACT");
        _contactsServices.ViewOneContact(answer);
        Console.ReadKey();
    }
    private void ShowRemoveContactMenu()
    {
        
        Console.Clear();
        Display("REMOVE CONTACT");
        Console.WriteLine("Insert email: ");
        var answer = Console.ReadLine()!;

        if (_contactsServices.RemoveContact(answer))
        {
            Console.WriteLine("Contact removed successfully.");
            
        }
        else
        {
            Console.WriteLine("Contact not found or couldn't be removed.");
        }

        Console.ReadKey();
    }
    private void ExitApplication()
    {
        Environment.Exit(0);
    }
    private void Display(string menu)
    {
        Console.WriteLine($" ---|| {menu} ||--- ");
        Console.WriteLine(" ----------------------");
        Console.WriteLine();

    }
    
    
}
