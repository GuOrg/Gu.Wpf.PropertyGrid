namespace Gu.Wpf.PropertyGrid
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    [ContentProperty(nameof(Templates))]
    public class ValidationErrorTemplateSelector : DataTemplateSelector
    {
        public List<DataTemplate> Templates { get; set; } = new List<DataTemplate>();

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null)
            {
                var match = this.Templates.FirstOrDefault(x => x.DataType == item.GetType());
                if (match != null)
                {
                    return match;
                }
            }

            return base.SelectTemplate(item, container);
        }
    }
}
