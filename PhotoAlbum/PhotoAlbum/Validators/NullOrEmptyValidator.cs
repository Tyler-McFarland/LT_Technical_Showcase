using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Interfaces;

namespace PhotoAlbum.Validators
{
    class NullOrEmptyValidator : IValidator
    {
        public bool Validate(string stringToValidate, bool canBeEmpty)
        {
            if (stringToValidate == null)
                return false;

            if (stringToValidate == String.Empty && canBeEmpty)
                return true;
            else
                return false;
        }
    }
}
