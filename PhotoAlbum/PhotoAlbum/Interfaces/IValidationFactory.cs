namespace PhotoAlbum.Interfaces
{
    public interface IValidationFactory
    {
        IValidator GetValidations(string validation);
    }
}