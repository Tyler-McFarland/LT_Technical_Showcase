using System;
using PhotoAlbum.Interfaces;
using PhotoAlbum.Enums;

namespace PhotoAlbum.Controllers
{
    public class ValidationController : IValidationController 
    {
        public string ValidateStringToInt(string stringToValidate, IValidationFactory validationFactory)
        {
            string messageToReturn = string.Empty;

            foreach (string validationName in Enum.GetNames(typeof(ValidationEnums)))
            {
                IValidator handler = validationFactory.GetValidations(validationName);
                messageToReturn += handler.Validate(stringToValidate);
            }
            
            return messageToReturn;
        }
    }
}
