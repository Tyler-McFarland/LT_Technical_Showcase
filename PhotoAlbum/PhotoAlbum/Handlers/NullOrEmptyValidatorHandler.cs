using System;
using PhotoAlbum.Interfaces;

namespace PhotoAlbum.Handlers
{
    public class NullOrEmptyValidatorHandler : IValidator
    {
        public string Validate(string stringToValidate)
        {
            string messageForNullOrEmpty = "An empty value was passed, please pass a value";

            return string.IsNullOrEmpty(stringToValidate) 
                   ? messageForNullOrEmpty
                   : null;
        }
    }
}