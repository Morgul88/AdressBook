

using AdressBook.Interface;
using AdressBook.Models;
using AdressBook.Services;

namespace AdressBook.Tests;

public class ContactsService_Tests
{
    [Fact]
    public void AddContactToListShould_AddOneContactToContactList_ThenReturnTrue()
    {
        //Arrange
        IContacts testContacts = new Contacts { FirstName = "Henrik", Email = "henrik@gmail.com", PhoneNumber = "07333333" };

        

        ContactsServices contactsServices = new ContactsServices();

        //Act
        bool result = contactsServices.AddContact((Contacts)testContacts);

        //Assert
        Assert.True(result);

    }

    [Fact]
    public void GetAllFromListShould_GetAllContactsInContactList_ThenReturnListOfContacts()
    {
        //Arrange0
        
        ContactsServices contactsServices = new ContactsServices();
        IContacts testContacts = new Contacts { FirstName = "Henrik", Email = "henrik@gmail.com", PhoneNumber = "07333333" };
        contactsServices.AddContact((Contacts)testContacts);

        List<IContacts> contacts = new List<IContacts>();
        //Act
        List<IContacts> result = contactsServices.GetContactsFromList();

        //Assert
        Assert.NotNull(result);
        Assert.True(result.Any());

    }

    //[Fact]
    //public void RemoveContactToListShould_RemoveOneContactFromList_ThenReturnTrue()

    //{ 
    //    Contacts contacts = new Contacts();
    //    ContactsServices contactsServices = new ContactsServices();

    //    bool result = contactsServices.RemoveContact(string contacts);

    //    Assert.True(result);

    //}
}
