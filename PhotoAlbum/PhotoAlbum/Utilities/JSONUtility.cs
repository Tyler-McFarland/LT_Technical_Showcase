using System;
using System.Net;
using Newtonsoft.Json;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Models;

namespace PhotoAlbum.Utilities
{
    public class JSONUtility : IJSONUtility
    {
        public string GetJSONFromURL(string url, WebClient webClient)
        {
            string jsonString = string.Empty;

            using (webClient)
            {
                jsonString = webClient.DownloadString(url);
            }

            return jsonString;
        }

        public Album[] ParseJson(string jsonString)
        {
            Album[] parsedObject = null;

            parsedObject = JsonConvert.DeserializeObject<Album[]>(jsonString);

            return parsedObject;
        }
    }
}
