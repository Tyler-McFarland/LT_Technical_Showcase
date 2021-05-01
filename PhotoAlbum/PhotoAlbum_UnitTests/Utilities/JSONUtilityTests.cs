using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Models;
using PhotoAlbum.Utilities;
using Rhino.Mocks;

namespace PhotoAlbum_UnitTests.Utilities
{
    [TestClass]
    public class JSONUtilityTests
    {
        private IJSONUtility _jsonUtility;
        private WebClient _mockWebClient;

        [TestInitialize]
        public void Initialize()
        {
            _jsonUtility = new JSONUtility();
            _mockWebClient = MockRepository.GenerateMock<WebClient>();
        }
        

        [TestMethod]
        public void GetJSONFromURL_WhenNoExceptionThrownOnRequest_ReturnsGivenJsonString()
        {
            string url = "testUrl";
            string returnJson = "json";

            _mockWebClient
                .Stub(x => x.DownloadString(url))
                .Return(returnJson);

            string actualJson = _jsonUtility.GetJSONFromURL(url, _mockWebClient);

            Assert.AreEqual(returnJson, actualJson);
        }

        [TestMethod, ExpectedException(typeof(WebException))]
        public void GetJSONFromURL_WhenInvalidURL_ThrowsException()
        {
            string url = "NotRealURL";

            WebClient realWebClient = new WebClient();

            _jsonUtility.GetJSONFromURL(url, realWebClient);
        }

        [TestMethod]
        public void ParseJson_WhenPassedValidJsonString_ReturnsArrayOfAlbum()
        {
            string albumId = "1";
            string id = "1";
            string title = "Test";
            string url = "testUrl";
            string thumbnailURL = "testUrl";
            string inputJsonString =
                "[{\"albumId\": \"1\", \"id\":\"1\",\"title\":\"Test\",\"url\":\"testUrl\",\"thumbnailUrl\":\"testUrl\"}]";
            Album[] expectedAlbum = new Album[1]
            {
                new Album(albumId, id, title, url, thumbnailURL)
            };

            Album[] actualAlbum = _jsonUtility.ParseJson(inputJsonString);

            Assert.AreEqual(actualAlbum.Length, expectedAlbum.Length);
            for (int i = 0; i < actualAlbum.Length; i++)
            {
                Assert.AreEqual(actualAlbum[i].AlbumId, expectedAlbum[i].AlbumId);
                Assert.AreEqual(actualAlbum[i].Id, expectedAlbum[i].Id);
                Assert.AreEqual(actualAlbum[i].Title, expectedAlbum[i].Title);
                Assert.AreEqual(actualAlbum[i].Url, expectedAlbum[i].Url);
                Assert.AreEqual(actualAlbum[i].ThumbnailUrl, expectedAlbum[i].ThumbnailUrl);
            }
        }

        [TestMethod, ExpectedException(typeof(JsonReaderException))]
        public void ParseJson_WhenPassedInvalidJsonString_ThrowsException()
        {
            string inputJsonString = "invalid";

            _jsonUtility.ParseJson(inputJsonString);
        }
    }
}
