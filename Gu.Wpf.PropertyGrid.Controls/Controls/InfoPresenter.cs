namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public class InfoPresenter : ContentControl
    {
        static InfoPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoPresenter), new FrameworkPropertyMetadata(typeof(InfoPresenter)));
            FocusableProperty.OverrideMetadataWithDefaultValue(typeof(InfoPresenter), false);
        }
    }
}
