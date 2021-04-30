namespace PhotoAlbum.Interfaces
{
    public interface IValidationHandler
    {
        
        bool ValidateString(string stringToValidate, bool CanBeEmpty);
    }
}