using PhotoAlbum.Models;

namespace PhotoAlbum.Interfaces
{
    public interface IJSONUtility
    {
         string GetJSONFromURL(string url);

         Album[] ParseJson(string jsonString);
    }
}