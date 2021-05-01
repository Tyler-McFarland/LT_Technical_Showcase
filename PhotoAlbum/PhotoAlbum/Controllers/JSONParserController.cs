using System;
using PhotoAlbum.Models;
using PhotoAlbum.Utilities;

namespace PhotoAlbum.Controllers
{
    public class JSONParserController
    {
        public Album[] GetAndParseJSON(string albumId)
        {
            string url = $"https://jsonplaceholder.typicode.com/photos?albumId={albumId}";
            string jsonString = String.Empty;
            Album[] parsedObject = null;

            GetJSON getJson = new GetJSON();
            try
            {
                jsonString = getJson.GetJSONFromURL(url);
            }
            catch (Exception e)
            {
                throw e;
            }

            ParseJSON parseJson = new ParseJSON();
            try
            {
                parsedObject = parseJson.ParseJson(jsonString);
            }
            catch (Exception e)
            {
                throw e;
            }

            return parsedObject;

        }
    }
}