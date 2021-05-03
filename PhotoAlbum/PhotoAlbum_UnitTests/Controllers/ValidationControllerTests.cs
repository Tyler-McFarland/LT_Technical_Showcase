using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Controllers;
using PhotoAlbum.Interfaces;
using Rhino.Mocks;
using PhotoAlbum.Enums;

namespace PhotoAlbum_UnitTests.Controllers
{
    /// <summary>
    /// Summary description for ValidationControllerTests
    /// </summary>
    [TestClass]
    public class ValidationControllerTests
    {
        private IValidationController _validationController;
        private IValidationFactory _mockValidationFactory;
        private IValidator _mockValidator;

        [TestInitialize]
        public void Initialize()
        {
            _validationController = new ValidationController();
            _mockValidationFactory = MockRepository.GenerateMock<IValidationFactory>();
            _mockValidator = MockRepository.GenerateMock<IValidator>();
        }

        [TestMethod]
        public void ValidateStringToInt_WhenCalled_CallsTheCorrectNumberOfHandlersAndValidators()
        {
            string inputString = "1";
            string returnString = string.Empty;

            _mockValidationFactory
                .Expect(x => x.GetValidations(inputString))
                .Repeat
                .Twice()
                .IgnoreArguments()
                .Return(_mockValidator);

            _mockValidator
                .Expect(x => x.Validate(inputString))
                .Repeat
                .Twice()
                .IgnoreArguments()
                .Return(returnString);

            _validationController.ValidateStringToInt(inputString, _mockValidationFactory);

            _mockValidationFactory.VerifyAllExpectations();
            _mockValidator.VerifyAllExpectations();

        }

        [TestMethod]
        public void ValidateStringToInt_CallsGetValidations_ForEachValidationEnum()
        {
            var inputString = Guid.NewGuid().ToString(); //An easy way to get random string values
            var expectedNames = Enum.GetNames(typeof(ValidationEnums));
            var mockHandlers = new List<IValidator>();
            var expected = string.Empty;
            foreach (var name in expectedNames)
            {
                var mockHandler = MockRepository.GenerateMock<IValidator>();
                _mockValidationFactory
                    .Expect(x => x.GetValidations(name))
                    .Repeat
                    .Once()
                    .Return(mockHandler);

                var randomString = Guid.NewGuid().ToString();
                expected += randomString;
                mockHandler
                    .Expect(x => x.Validate(inputString))
                    .Repeat
                    .Once()
                    .Return(randomString);
                
                mockHandlers.Add(MockRepository.GenerateMock<IValidator>());
            }

            var actual = _validationController.ValidateStringToInt(inputString, _mockValidationFactory);

            _mockValidationFactory.VerifyAllExpectations();
            _mockValidator.VerifyAllExpectations();
            Assert.AreEqual(expected, actual);
        }
    }
}
