using System;
using PhotoAlbum.Controllers;
using PhotoAlbum.Interfaces;

namespace PhotoAlbum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter an album ID: ");
            string albumId = Console.ReadLine();

            IValidationController validationController = new ValidationController();
            string returnMessage = validationController.ValidateStringToInt(albumId);

            Console.WriteLine(string.IsNullOrEmpty(returnMessage) 
                                ? "IsValidString" 
                                : returnMessage);

            Console.ReadLine();
        }
    }
}
