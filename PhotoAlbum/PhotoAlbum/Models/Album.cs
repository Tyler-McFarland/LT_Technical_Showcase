using Newtonsoft.Json;

namespace PhotoAlbum.Models
{
    [JsonObject]
    public class Album
    {
        public Album(string albumId, string id, string title, string url, string thumbnailUrl)
        {
            this.AlbumId = albumId;
            this.Id = id;
            this.Title = title;
            this.Url = url;
            this.ThumbnailUrl = thumbnailUrl;
        }

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