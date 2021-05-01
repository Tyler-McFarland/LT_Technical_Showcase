using Newtonsoft.Json;

namespace PhotoAlbum.Models
{
    [JsonObject]
    public class Album
    {
        [JsonProperty]
        public string AlbumId { get; set; }

        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Url { get; set; }

        [JsonProperty]
        public string ThumbnailUrl { get; set; }
    }
}