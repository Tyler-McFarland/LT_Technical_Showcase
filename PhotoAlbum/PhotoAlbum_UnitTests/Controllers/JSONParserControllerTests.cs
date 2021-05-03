using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Controllers;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Models;
using Rhino.Mocks;

namespace PhotoAlbum_UnitTests.Controllers
{
    /// <summary>
    /// Summary description for JSONParserTests
    /// </summary>
    [TestClass]
    public class JSONParserTests
    {
        private IJSONParserController _jsonParserController;
        private IJSONUtility _mockJsonUtility;
        private WebClient _mockWebClient;

        [TestInitialize]
        public void Initialize()
        {
            _jsonParserController = new JSONParserController();
            _mockJsonUtility = MockRepository.GenerateMock<IJSONUtility>();
            _mockWebClient = MockRepository.GenerateMock<WebClient>();
        }

        [TestMethod]
        public void GetAndParseJSON_WhenPassedValidAlbumId_CallsBothUtilities()
        {
            string inputAlbumId = "1";
            string inputUrl = $"https://jsonplaceholder.typicode.com/photos?albumId={inputAlbumId}";
            string returnJsonString = null;

            _jsonParserController.GetAndParseJSON(inputAlbumId, _mockJsonUtility, _mockWebClient);

            _mockJsonUtility.AssertWasCalled(x => x.GetJSONFromURL(inputUrl, _mockWebClient));
            _mockJsonUtility.AssertWasCalled(x => x.ParseJson(returnJsonString));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetAndParseJSON_ThrowsCaughtExpection_WhenExpectionThrown()
        {
            string inputAlbumId = "1";
            string inputUrl = $"https://jsonplaceholder.typicode.com/photos?albumId={inputAlbumId}";
            _mockJsonUtility
                .Expect(x => x.GetJSONFromURL(inputUrl, _mockWebClient))
                .Throw(new ArgumentException());

            _jsonParserController.GetAndParseJSON(inputAlbumId, _mockJsonUtility, _mockWebClient);
        }
    }
}
