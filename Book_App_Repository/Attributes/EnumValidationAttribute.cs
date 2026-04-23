namespace Book_App.Attributes
{
    public class EnumValidationAttribute : BaseValidationAttribute
    {
        private readonly Type _enumType;

        public EnumValidationAttribute(Type enumType)
        {
            _enumType = enumType;
        }

        public override bool IsValid(object value, out string errorMessage)
        {
            if (value == null)
            {
                errorMessage = "Value is required";
                return false;
            }

            if (!Enum.IsDefined(_enumType, value))
            {
                errorMessage = "Invalid selection";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
