namespace Gu.Wpf.PropertyGrid.Demo
{
    using System.Windows.Controls;

    public class NumberValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var canConvert = double.TryParse(value as string, out var result);
            if (canConvert)
            {
                canConvert = result >= 0 && result <= 10;
            }

            return new ValidationResult(canConvert, "Not a valid double 0-10");
        }
    }
}
