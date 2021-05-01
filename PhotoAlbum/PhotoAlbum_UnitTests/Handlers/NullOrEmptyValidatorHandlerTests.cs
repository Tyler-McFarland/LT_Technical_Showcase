using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Handlers;
using PhotoAlbum.Interfaces;

namespace PhotoAlbum_UnitTests.Handlers
{
    [TestClass]
    public class NullOrEmptyValidatorHandlerTests
    {
        private IValidator _nullOrEmptyValidatorHandler;

        [TestInitialize]
        public void Initialize()
        {
            _nullOrEmptyValidatorHandler = new NullOrEmptyValidatorHandler();
        }

        [TestMethod]
        public void Validate_WhenPassedValue_ReturnsNull()
        {
            string inputString = "1";
            string expectedReturn = null;

            string actualReturn = _nullOrEmptyValidatorHandler.Validate(inputString);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void Validate_WhenPassedNull_ReturnsErrorMessage()
        {
            string inputString = null;
            string expectedReturn = "An empty value was passed, please pass a value";

            string actualReturn = _nullOrEmptyValidatorHandler.Validate(inputString);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void Validate_WhenPassedEmptyString_ReturnsErrorMessage()
        {
            string inputString = string.Empty;
            string expectedReturn = "An empty value was passed, please pass a value";

            string actualReturn = _nullOrEmptyValidatorHandler.Validate(inputString);

            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
