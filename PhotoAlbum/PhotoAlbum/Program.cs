using System;
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
            #region Variables
            IValidationController validationController = new ValidationController();
            IJSONParserController jsonParserController = new JSONParserController();
            FormatStringUtility formatString = new FormatStringUtility();
            bool isValidInput = false;
            string albumId = string.Empty;
            string outputString = string.Empty;
            Album[] album = null;
            #endregion

            #region GetAndValidateInput
            //Get User input for album and Validate
            while (!isValidInput)
            {
                Console.Write("Please enter an album ID: ");
                albumId = Console.ReadLine();

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
            #endregion

            #region GetAndParseJSON
            //Get and parse the json for output
            try
            {
                album = jsonParserController.GetAndParseJSON(albumId);
            }
            catch (Exception)
            {
                Console.WriteLine($"A problem occurred when Getting and parsing the Json, please try again{Environment.NewLine}");
                Main(null);
            }
            #endregion

            #region OutputJSON
            //Format string for output
            outputString = formatString.FormatAlbumArray(album);
            Console.WriteLine(string.IsNullOrEmpty(outputString)
                ? $"No information returned for AlbumId: {albumId}"
                : outputString);
            Console.ReadLine();
            #endregion
        }
    }
}
