using System;
using PhotoAlbum.Controllers;
using PhotoAlbum.Interfaces;

namespace PhotoAlbum
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write("Please enter an album ID: ");
                string albumId = Console.ReadLine();

                IValidationController validationController = new ValidationController();
                string returnMessage = validationController.ValidateStringToInt(albumId);

                if (string.IsNullOrEmpty(returnMessage))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine(returnMessage);
                    isValidInput = false;
                }
            }




        }
    }
}
