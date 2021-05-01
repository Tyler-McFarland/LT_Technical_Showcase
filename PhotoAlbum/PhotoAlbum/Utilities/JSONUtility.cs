using System;
using System.Net;
using Newtonsoft.Json;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Models;

namespace PhotoAlbum.Utilities
{
    public class JSONUtility : IJSONUtility
    {
        public string GetJSONFromURL(string url)
        {
            string jsonString = string.Empty;

            try
            {
                using (WebClient web = new WebClient())
                {
                    jsonString = web.DownloadString(url);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return jsonString;
        }

        public Album[] ParseJson(string jsonString)
        {
            Album[] parsedObject = null;

            try
            {
                parsedObject = JsonConvert.DeserializeObject<Album[]>(jsonString);
            }
            catch (Exception e)
            {
                throw e;
            }

            return parsedObject;
        }
    }
}