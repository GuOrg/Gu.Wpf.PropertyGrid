namespace Gu.Wpf.PropertyGrid.Demo
{
    using System.Globalization;
    using System.Windows.Controls;

    public class IntValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var canConvert = value != null && int.TryParse(value.ToString(), out var _);
            return canConvert ? new ValidationResult(isValid: true, errorContent: null) : new ValidationResult(isValid: false, errorContent: $"Input should be type of Int32");
        }
    }
}
