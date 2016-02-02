namespace Gu.Wpf.PropertyGrid
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Controls;

    [TypeConverter(typeof(ColumnDefinitionsConverter))]
    public class ColumnDefinitions : List<ColumnDefinition>
    {
        public ColumnDefinitions()
        {
        }

        public ColumnDefinitions(IEnumerable<ColumnDefinition> collection) 
            : base(collection)
        {
        }
    }
}