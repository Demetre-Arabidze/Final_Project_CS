namespace Book_App.Attributes
{
    public class StringLengthAttribute : BaseValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;

        public StringLengthAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public override bool IsValid(object value, out string errorMessage)
        {
            var str = value as string;

            if (str == null)
            {
                errorMessage = "Invalid string";
                return false;
            }

            if (str.Length < _min || str.Length > _max)
            {
                errorMessage = $"Length must be between {_min} and {_max}";
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}
