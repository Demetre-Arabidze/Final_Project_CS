namespace Book_App.Attributes
{
    public class RequiredAttribute : BaseValidationAttribute
    {
        public override bool IsValid(object value, out string errorMessage)
        {
            if (value == null || (value is string s && string.IsNullOrWhiteSpace(s)))
            {
                errorMessage = "Field is required";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
