using System.Net;
using PhotoAlbum.Models;

namespace PhotoAlbum.Interfaces
{
    public interface IJSONUtility
    {
         string GetJSONFromURL(string url, WebClient webClient);

         Album[] ParseJson(string jsonString);
    }
}