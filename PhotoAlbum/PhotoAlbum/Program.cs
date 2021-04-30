using System;
using PhotoAlbum.Interfaces;
using PhotoAlbum.ValidationHandler;

namespace PhotoAlbum
{
    class Program
    {
        static void Main(string[] args)
        {
            string albumId = string.Empty;

            Console.Write("Please enter an album ID: ");
            albumId = Console.ReadLine();


            //TODO: Try and find a way for this to not require the name space
            IValidationHandler validationHandler = new ValidationHandler.ValidationHandler();
            validationHandler.ValidateString(albumId, false);
        }
    }
}
