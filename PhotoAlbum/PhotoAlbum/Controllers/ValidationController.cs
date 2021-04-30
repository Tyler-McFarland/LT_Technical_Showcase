using System;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Enums;

namespace PhotoAlbum.Controllers
{
    public class ValidationController : IValidationController 
    {
        public string ValidateStringToInt(string stringToValidate)
        {
            string messageToReturn = string.Empty;
            IValidationFactory validationFactory = new ValidationFactory();

            foreach (string validatioName in Enum.GetNames(typeof(ValidationEnums)))
            {
                IValidator handler = validationFactory.GetValidations(validatioName);
                messageToReturn += handler.Validate(stringToValidate);
            }
            
            return messageToReturn;
        }
    }
}
