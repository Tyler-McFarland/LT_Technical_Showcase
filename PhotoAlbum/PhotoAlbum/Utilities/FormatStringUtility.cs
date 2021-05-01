using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Models;

namespace PhotoAlbum.Utilities
{
    class FormatStringUtility : IFormatStringUtility
    {
        public string FormatAlbumArray(Album[] albums)
        {
            if (albums.Length == 0)
                return String.Empty;
            
            StringBuilder formattedString = new StringBuilder();

            formattedString.Append($"Album ID: {albums[0].AlbumId}{Environment.NewLine}");

            foreach (var photo in albums)
            {
                //Extra space for readability
                formattedString.Append($"{ Environment.NewLine}");
                formattedString.Append($"Photo Id: {photo.Id}{Environment.NewLine}");
                formattedString.Append($"Photo Title: {photo.Title}{Environment.NewLine}");
            }

            return formattedString.ToString();
        }
    }
}
