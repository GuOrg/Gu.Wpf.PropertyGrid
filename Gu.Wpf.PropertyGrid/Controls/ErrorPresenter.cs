namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public class ErrorPresenter : ContentPresenter
    {
        static ErrorPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ErrorPresenter), new FrameworkPropertyMetadata(typeof(ErrorPresenter)));
            FocusableProperty.OverrideMetadataWithDefaultValue(typeof(ErrorPresenter), false);
        }
    }
}
