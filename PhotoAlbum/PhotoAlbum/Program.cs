using System;
using System.Net;
using Microsoft.SqlServer.Server;
using PhotoAlbum.Controllers;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Models;
using PhotoAlbum.Utilities;

namespace PhotoAlbum
{
    class Program
    {
        static void Main(string[] args)
        {
            string albumId = GetAndValidateInput();

            Album[] album = GetAndParseJSON(albumId);

            OutputJSON(album, albumId);
        }

        public static string GetAndValidateInput()
        {
            IValidationController validationController = new ValidationController();
            IValidationFactory validationFactory = new ValidationFactory();
            bool isValidInput = false;
            string albumId = string.Empty;
            
            while (!isValidInput)
            {
                Console.Write("Please enter an album ID: ");
                albumId = Console.ReadLine();

                string returnMessage = validationController.ValidateStringToInt(albumId, validationFactory);

                if (string.IsNullOrEmpty(returnMessage))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine(returnMessage);
                    Console.WriteLine($"{Environment.NewLine}");
                    isValidInput = false;
                }
            }

            return albumId;
        }

        public static Album[] GetAndParseJSON(string albumId)
        {   
            try
            {
                IJSONParserController jsonParserController = new JSONParserController();
                IJSONUtility jsonUtility = new JSONUtility();
                WebClient webClient = new WebClient();

                Album[] album = jsonParserController.GetAndParseJSON(albumId, jsonUtility, webClient);
                return album;
            }
            catch (Exception)
            {
                Console.WriteLine($"A problem occurred when Getting and parsing the Json, please try again{Environment.NewLine}");
                Main(null);
                return null;
            }
        }

        public static void OutputJSON(Album[] album, string albumId)
        {
            IFormatStringUtility formatString = new FormatStringUtility();
            string outputString = formatString.FormatAlbumArray(album);
            
            if (string.IsNullOrEmpty(outputString))
            {
                Console.WriteLine($"No information returned for AlbumId: {albumId}");
                Console.WriteLine($"{Environment.NewLine}");
                Main(null);
            }
            else
            {
                Console.WriteLine(outputString);
            }

            Console.ReadLine();
        }
    }
}
