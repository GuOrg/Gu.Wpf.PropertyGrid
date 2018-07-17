namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    /// <summary>
    /// A property grid row for arbitrary content.
    /// </summary>
    public partial class ContentRow : GenericRow<object>
    {
        static ContentRow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContentRow), new FrameworkPropertyMetadata(typeof(ContentRow)));
        }
    }
}
