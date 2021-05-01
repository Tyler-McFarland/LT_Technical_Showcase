using System;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Models;
using PhotoAlbum.Utilities;

namespace PhotoAlbum.Controllers
{
    public class JSONParserController : IJSONParserController
    {
        public Album[] GetAndParseJSON(string albumId)
        {
            string url = $"https://jsonplaceholder.typicode.com/photos?albumId={albumId}";
            string jsonString = String.Empty;
            Album[] parsedObject = null;

            JSONUtility jsonUtility = new JSONUtility();
            try
            {
                jsonString = jsonUtility.GetJSONFromURL(url);
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                parsedObject = jsonUtility.ParseJson(jsonString);
            }
            catch (Exception e)
            {
                throw e;
            }

            return parsedObject;

        }
    }
}