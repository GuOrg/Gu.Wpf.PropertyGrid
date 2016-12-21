namespace Gu.Wpf.PropertyGrid
{
    using System.Collections.Generic;
    using System.ComponentModel;

    [TypeConverter(typeof(ColumnDefinitionsConverter))]
    public class ColumnDefinitions : List<System.Windows.Controls.ColumnDefinition>
    {
        public ColumnDefinitions()
        {
        }

        public ColumnDefinitions(IEnumerable<System.Windows.Controls.ColumnDefinition> collection)
            : base(collection)
        {
        }
    }
}