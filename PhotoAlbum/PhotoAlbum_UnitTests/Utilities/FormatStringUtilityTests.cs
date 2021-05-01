using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Models;
using PhotoAlbum.Utilities;

namespace PhotoAlbum_UnitTests.Utilities
{
    [TestClass]
    public class FormatStringUtilityTests
    {
        private IFormatStringUtility _formatStringUtility;

        [TestInitialize]
        public void Initialize()
        {
            _formatStringUtility = new FormatStringUtility();
        }

        [TestMethod]
        public void FormatAlbumArray_WhenCalledWithEmptyArray_ReturnsEmptyString()
        {
            Album[] albums = new Album[0];
            string expectedString = string.Empty;

            string actualString = _formatStringUtility.FormatAlbumArray(albums);

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void FormatAlbumArray_WhenCalledWithValidArray_ReturnsFormattedString()
        {
            string albumId = "1";
            string id = "1";
            string title = "title";
            string url = "test";
            string thumbnailUrl = "test";
            Album[] inputAlbum = new Album[1]
            {
                new Album(albumId, id, title, url, thumbnailUrl)
            };

            string expectedAlbumId = $"Album ID: {albumId}";
            string expectedPhotoId = $"Photo Id: {id}";
            string expectedPhotoTitle = $"Photo Title: {title}";

            string actualString = _formatStringUtility.FormatAlbumArray(inputAlbum);

            Assert.IsTrue(actualString.Contains(expectedAlbumId));
            Assert.IsTrue(actualString.Contains(expectedPhotoId));
            Assert.IsTrue(actualString.Contains(expectedPhotoTitle));
        }
    }
}
