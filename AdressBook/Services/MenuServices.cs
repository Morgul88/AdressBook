
using AdressBook.Interface;
using AdressBook.Models;
using System.Security.Cryptography;

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
            Console.WriteLine(" 3. VIEW CONTACT");
            Console.WriteLine();
            Console.WriteLine(" 4. REMOVE CONTACT");
            Console.WriteLine();
            Console.WriteLine(" 5. SAVE CONTACTS");
            Console.WriteLine();
            Console.WriteLine(" 6. EXIT");
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
                    ShowRemoveContactMenu();                   
                    break;
                case "5":
                    ShowSaveMenu();
                    break;
                case "6":
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
        Console.WriteLine("Vill du spara dina kontakter? y/n");
        var answer = Console.ReadLine()!.ToLower() ;
        if(answer == "y")
        {
            _contactsServices.SaveFile();

        }
        else
        {
            Console.WriteLine();
        }
    }
    public void ShowAddMenu()
    {
        
        IContacts contacts = new Contacts();
        contacts.Id = ContactsServices._contactIdCounter++;

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
    private void ShowAllUsersMenu()
    {
        IContacts contacts = new Contacts();
        Console.Clear();
        Display("CONTACTS:");

        _contactsServices.ViewAllContacts();
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
