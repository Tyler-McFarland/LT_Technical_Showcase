using System;
using System.Net;
using PhotoAlbum.Models;

namespace PhotoAlbum.Utilities
{
    public class GetJSON
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
    }
}