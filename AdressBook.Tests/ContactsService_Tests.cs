

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
        Contacts contacts = new Contacts();
        ContactsServices contactsServices = new ContactsServices();

        //Act
        bool result = contactsServices.AddContact(contacts);

        //Assert
        Assert.True(result);

    }

    [Fact]
    public void GetAllFromListShould_GetAllContactsInContactList_ThenReturnListOfContacts()
    {
        //Arrange0
        
        ContactsServices contactsServices = new ContactsServices();

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
