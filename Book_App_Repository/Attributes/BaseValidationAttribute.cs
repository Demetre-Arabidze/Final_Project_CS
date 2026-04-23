namespace Book_App.Attributes
{
    public abstract class BaseValidationAttribute : Attribute
    {
        public abstract bool IsValid(object value, out string errorMessage);
    }
}
