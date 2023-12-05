

using AdressBook.Interface;

namespace AdressBook.Models
    ;

public class Contacts : IContacts
{
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string HomeAdress { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public int  Id { get; set; }
    
}
