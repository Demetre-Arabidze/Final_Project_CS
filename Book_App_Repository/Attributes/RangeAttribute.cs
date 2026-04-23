namespace Book_App.Attributes
{
    public class RangeAttribute : BaseValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;

        public RangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public override bool IsValid(object value, out string errorMessage)
        {
            if (value == null || !int.TryParse(value.ToString(), out int number))
            {
                errorMessage = "Invalid number";
                return false;
            }

            if (number < _min || number > _max)
            {
                errorMessage = $"Value must be between {_min} and {_max}";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
