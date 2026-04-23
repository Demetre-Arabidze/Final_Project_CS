namespace Book_App.Attributes
{
    public class YearAttribute : BaseValidationAttribute
    {
        public override bool IsValid(object value, out string errorMessage)
        {
            if (!int.TryParse(value?.ToString(), out int year))
            {
                errorMessage = "Invalid year";
                return false;
            }

            if (year < 1000 || year > DateTime.Now.Year)
            {
                errorMessage = "Year is not valid";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
