using Book_App.Attributes;

namespace Book_App.Validators
{
    public static class Validator
    {
        public static List<string> Validate(object obj)
        {
            var errors = new List<string>();

            var properties = obj.GetType().GetProperties();

            foreach (var prop in properties)
            {
                var value = prop.GetValue(obj);

                var attributes = prop.GetCustomAttributes(typeof(BaseValidationAttribute), true);

                foreach (BaseValidationAttribute attr in attributes)
                {
                    if (!attr.IsValid(value, out string errorMessage))
                    {
                        errors.Add($"{prop.Name}: {errorMessage}");
                    }
                }
            }

            return errors;
        }
    }
}
