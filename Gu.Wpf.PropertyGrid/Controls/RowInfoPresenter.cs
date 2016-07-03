namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public class RowInfoPresenter : Control
    {
        static RowInfoPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RowInfoPresenter), new FrameworkPropertyMetadata(typeof(RowInfoPresenter)));
            FocusableProperty.OverrideMetadataWithDefaultValue(typeof(RowInfoPresenter), false);
        }
    }
}
