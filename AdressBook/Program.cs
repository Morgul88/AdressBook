using AdressBook.Interface;
using AdressBook.Services;

MenuServices menuService = new MenuServices();
ContactsServices contactsServices = new ContactsServices();
contactsServices.GetContactsFromComp();
menuService.ShowMainMenu();