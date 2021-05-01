using System;
using PhotoAlbum.Interfaces;

namespace PhotoAlbum.Handlers
{
    public class CanBeConvertedToIntValidatorHandler : IValidator
    {
        public string Validate(string stringToValidate)
        {
            string messageForNonConvertable = "Passed value was not a number, please pass a number";

            bool IsNumeric = int.TryParse(stringToValidate, out _);

            return IsNumeric
                ? null
                : messageForNonConvertable;
        }
    }
}