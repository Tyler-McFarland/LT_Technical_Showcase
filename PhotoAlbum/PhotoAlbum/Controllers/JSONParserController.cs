using System;
using System.Net;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Models;
using PhotoAlbum.Utilities;

namespace PhotoAlbum.Controllers
{
    public class JSONParserController : IJSONParserController
    {
        public Album[] GetAndParseJSON(string albumId, IJSONUtility jsonUtility, WebClient webClient)
        {
            string url = $"https://jsonplaceholder.typicode.com/photos?albumId={albumId}";
            string jsonString = String.Empty;
            Album[] parsedObject = null;

            try
            {
                jsonString = jsonUtility.GetJSONFromURL(url, webClient);
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
