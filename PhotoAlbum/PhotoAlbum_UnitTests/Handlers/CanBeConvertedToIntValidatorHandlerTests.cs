using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Handlers;
using PhotoAlbum.Interfaces;

namespace PhotoAlbum_UnitTests.Handlers
{
    [TestClass]
    public class CanBeConvertedToIntValidatorHandlerTests
    {
        private IValidator _canBeConvertedToIntValidatorHandler;

        [TestInitialize]
        public void Initialize()
        {
            _canBeConvertedToIntValidatorHandler = new CanBeConvertedToIntValidatorHandler();
        }

        [TestMethod]
        public void Validate_WhenPassedNumber_ReturnsNull()
        {
            string inputString = "1";
            string expectedReturn = null;

            string actualReturn = _canBeConvertedToIntValidatorHandler.Validate(inputString);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void Validate_WhenPassedNonNumber_ReturnsErrorMessage()
        {
            string inputString = "A";
            string expectedReturn = "Passed value was not a number, please pass a number";

            string actualReturn = _canBeConvertedToIntValidatorHandler.Validate(inputString);

            Assert.AreEqual(expectedReturn, actualReturn);
        }
    }
}
