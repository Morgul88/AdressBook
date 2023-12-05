namespace AdressBook.Interface
{
    public interface IContacts
    {
        string Email { get; set; } 
        string FirstName { get; set; } 
        string HomeAdress { get; set; } 
        
        string PhoneNumber { get; set; }

        public int Id { get; set; }
    }
}