namespace Gu.Wpf.PropertyGrid
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Controls;

    [TypeConverter(typeof(RowDefinitionsConverter))]
    public class RowDefinitions : List<RowDefinition>
    {
        public RowDefinitions()
        {
        }

        public RowDefinitions(IEnumerable<RowDefinition> definitions)
            : base(definitions)
        {
        }
    }
}