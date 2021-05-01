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
            string albumId = string.Empty;

            while (!isValidInput)
            {
                Console.Write("Please enter an album ID: ");
                albumId = Console.ReadLine();

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

            JSONParserController jsonParserController = new JSONParserController();
            try
            {
                jsonParserController.GetAndParseJSON(albumId);
            }
            catch (Exception e)
            {
                Console.WriteLine($"A problem occurred when Getting and parsing the Json, please try again{Environment.NewLine}");
                Main(null);
            }


        }
    }
}
