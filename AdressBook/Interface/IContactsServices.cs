using AdressBook.Models;

namespace AdressBook.Interface
{
    public interface IContactsServices
    {
        /// <summary>
        /// Stoppar in en kontakt och lägger till kontakt i _customerList från customerService
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        bool AddContact(Contacts contact);


        /// <summary>
        /// Stoppar in en mail som letar upp en kontakt i listan med samma mail. Tar bort den kontakten från listan. Gör också en sparning av fil.
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        bool RemoveContact(string mail);


       
        /// <summary>
        /// Stoppar in en mail som letar upp en specifik kontakt. Loggar ut den kontakten med Console.WriteLine
        /// </summary>
        /// <param name="mail"></param>
        void ViewOneContact(string mail);



        /// <summary>
        /// Hämtar listan.
        /// </summary>
        /// <returns>Returnerar listan</returns>
        List<IContacts> GetContactsFromList();
    }
}