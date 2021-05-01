using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Controllers;
using PhotoAlbum.Interfaces;
using Rhino.Mocks;

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
                .Return(_mockValidator);

            _mockValidator
                .Expect(x => x.Validate(inputString))
                .Repeat
                .Twice()
                .Return(returnString);

            _validationController.ValidateStringToInt(inputString);
        }
    }
}
