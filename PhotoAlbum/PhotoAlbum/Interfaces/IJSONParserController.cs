using PhotoAlbum.Models;

namespace PhotoAlbum.Interfaces
{
    public interface IJSONParserController
    {
        Album[] GetAndParseJSON(string albumId);
    }
}