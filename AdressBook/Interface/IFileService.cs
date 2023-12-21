namespace AdressBook.Interface
{
    public interface IFileService
    {
        /// <summary>
        /// Hämtar min fil från datorn genom streamreader
        /// </summary>
        /// <returns></returns>
        string GetContentFromFile();

        /// <summary>
        /// Sparar fil på datorn genom streamwriter
        /// </summary>
        /// <param name="content"></param>
        /// <returns>Returnerar true om de lyckas</returns>
        bool SaveContentToFile(string content);
    }
}