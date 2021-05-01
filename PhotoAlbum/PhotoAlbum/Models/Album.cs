using Newtonsoft.Json;

namespace PhotoAlbum.Models
{
    [JsonObject]
    public class Album
    {

        private string AlbumId { get; set; }

        private string Id { get; set; }

        private string Title { get; set; }

        private string Url { get; set; }

        private string ThumbnailUrl { get; set; }
    }
}