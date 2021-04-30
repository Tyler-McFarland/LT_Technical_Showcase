namespace PhotoAlbum.Interfaces
{
    public interface IValidator
    {
        bool Validate(string stringToValidate, bool CanBeEmpty);
    }
}