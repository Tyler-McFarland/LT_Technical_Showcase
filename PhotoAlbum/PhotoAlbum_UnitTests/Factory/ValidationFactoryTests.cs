using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum;
using PhotoAlbum.Handlers;
using PhotoAlbum.Interfaces;
using Rhino.Mocks;

namespace PhotoAlbum_UnitTests.Factory
{
    [TestClass]
    public class ValidationFactoryTests
    {
        private IValidationFactory _validationFactory;

        [TestInitialize]
        public void Initialize()
        {
            _validationFactory = new ValidationFactory();
        }

        [TestMethod]
        public void GetValidations_WhenPassedInvalidValidator_ReturnsNull()
        {
            string invalidValidator = "DoesNotExist";
            IValidator expectedReturn = null;

            IValidator actualReturn = _validationFactory.GetValidations(invalidValidator);

            Assert.AreEqual(expectedReturn, actualReturn);
        }

        [TestMethod]
        public void GetValidations_WhenPassedNullOrEmptyValidator_ReturnsNullOrEmptyHandler()
        {
            string validValidator = "NullOrEmptyValidator";
            IValidator expectedReturn = new NullOrEmptyValidatorHandler();

            IValidator actualReturn = _validationFactory.GetValidations(validValidator);

            Assert.AreEqual(expectedReturn.GetType(), actualReturn.GetType());
        }

        [TestMethod]
        public void GetValidations_WhenPassedCanBeConvertedToIntValidator_ReturnsCanBeConvertedToIntHandler()
        {
            string validValidator = "CanBeConvertedToIntValidator";
            IValidator expectedReturn = new CanBeConvertedToIntValidatorHandler();

            IValidator actualReturn = _validationFactory.GetValidations(validValidator);

            Assert.AreEqual(expectedReturn.GetType(), actualReturn.GetType());
        }
    }
}
