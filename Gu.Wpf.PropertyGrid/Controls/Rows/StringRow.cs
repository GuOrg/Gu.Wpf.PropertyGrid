namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// A property grid row for string values.
    /// </summary>
    public class StringRow : GenericRow<string>
    {
        static StringRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StringRow), new FrameworkPropertyMetadata(typeof(StringRow)));
            ValueProperty.OverrideMetadataWithUpdateSourceTrigger(typeof(StringRow), UpdateSourceTrigger.LostFocus);
        }
    }
}