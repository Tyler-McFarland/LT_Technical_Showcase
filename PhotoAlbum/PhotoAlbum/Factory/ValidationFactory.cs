using System;
using System.Collections;
using PhotoAlbum.Enums;
using PhotoAlbum.Handlers;
using PhotoAlbum.Interfaces;

namespace PhotoAlbum
{
    public class ValidationFactory : IValidationFactory
    {
        public IValidator GetValidations(string validator)
        {
            ValidationEnums validationEnum;

            if (!Enum.TryParse(validator, out validationEnum)) return null;

            switch (validationEnum)
            {
                case ValidationEnums.NullOrEmptyValidator: 
                    return new NullOrEmptyValidatorHandler();
                case ValidationEnums.CanBeConvertedToIntValidator:
                    return new CanBeConvertedToIntValidatorHandler();
            }

            return null;
        }
    }
}