#pragma warning disable SA1402 // File may only contain a single class
namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class PropertyGrid
    {
        public static readonly DependencyProperty HeaderStyleProperty = DependencyProperty.RegisterAttached(
            "HeaderStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueStyleProperty = DependencyProperty.RegisterAttached(
            "ValueStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixStyleProperty = DependencyProperty.RegisterAttached(
            "SuffixStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = DependencyProperty.RegisterAttached(
            "OldValueStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = DependencyProperty.RegisterAttached(
            "ErrorStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public static void SetHeaderStyle(this UIElement element, Style value)
        {
            element.SetValue(HeaderStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetHeaderStyle(this UIElement element)
        {
            return (Style)element.GetValue(HeaderStyleProperty);
        }

        public static void SetValueStyle(this UIElement element, Style value)
        {
            element.SetValue(ValueStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetValueStyle(this UIElement element)
        {
            return (Style)element.GetValue(ValueStyleProperty);
        }

        public static void SetSuffixStyle(this UIElement element, Style value)
        {
            element.SetValue(SuffixStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetSuffixStyle(this UIElement element)
        {
            return (Style)element.GetValue(SuffixStyleProperty);
        }

        public static void SetOldValueStyle(this UIElement element, Style value)
        {
            element.SetValue(OldValueStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetOldValueStyle(this UIElement element)
        {
            return (Style)element.GetValue(OldValueStyleProperty);
        }

        public static void SetErrorStyle(this UIElement element, Style value)
        {
            element.SetValue(ErrorStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetErrorStyle(this UIElement element)
        {
            return (Style)element.GetValue(ErrorStyleProperty);
        }
    }

    public partial class Rows
    {
        public static readonly DependencyProperty HeaderStyleProperty = PropertyGrid.HeaderStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueStyleProperty = PropertyGrid.ValueStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixStyleProperty = PropertyGrid.SuffixStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = PropertyGrid.OldValueStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = PropertyGrid.ErrorStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        public Style HeaderStyle
        {
            get { return (Style)this.GetValue(HeaderStyleProperty); }
            set { this.SetValue(HeaderStyleProperty, value); }
        }

        public Style ValueStyle
        {
            get { return (Style)this.GetValue(ValueStyleProperty); }
            set { this.SetValue(ValueStyleProperty, value); }
        }

        public Style SuffixStyle
        {
            get { return (Style)this.GetValue(SuffixStyleProperty); }
            set { this.SetValue(SuffixStyleProperty, value); }
        }

        public Style OldValueStyle
        {
            get { return (Style)this.GetValue(OldValueStyleProperty); }
            set { this.SetValue(OldValueStyleProperty, value); }
        }

        public Style ErrorStyle
        {
            get { return (Style)this.GetValue(ErrorStyleProperty); }
            set { this.SetValue(ErrorStyleProperty, value); }
        }
    }

    public abstract partial class Row
    {
        public static readonly DependencyProperty ControlTemplateSelectorProperty = DependencyProperty.Register(
            nameof(ControlTemplateSelector),
            typeof(RowControlTemplateSelector),
            typeof(Row),
            new PropertyMetadata(
               default(RowControlTemplateSelector),
               OnPartStyleChanged));

        public static readonly DependencyProperty HeaderStyleProperty = PropertyGrid.HeaderStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public static readonly DependencyProperty ValueStyleProperty = PropertyGrid.ValueStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public static readonly DependencyProperty SuffixStyleProperty = PropertyGrid.SuffixStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public static readonly DependencyProperty OldValueStyleProperty = PropertyGrid.OldValueStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public static readonly DependencyProperty ErrorStyleProperty = PropertyGrid.ErrorStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public RowControlTemplateSelector ControlTemplateSelector
        {
            get { return (RowControlTemplateSelector)this.GetValue(ControlTemplateSelectorProperty); }
            set { this.SetValue(ControlTemplateSelectorProperty, value); }
        }

        public Style HeaderStyle
        {
            get { return (Style)this.GetValue(HeaderStyleProperty); }
            set { this.SetValue(HeaderStyleProperty, value); }
        }

        public Style ValueStyle
        {
            get { return (Style)this.GetValue(ValueStyleProperty); }
            set { this.SetValue(ValueStyleProperty, value); }
        }

        public Style SuffixStyle
        {
            get { return (Style)this.GetValue(SuffixStyleProperty); }
            set { this.SetValue(SuffixStyleProperty, value); }
        }

        public Style OldValueStyle
        {
            get { return (Style)this.GetValue(OldValueStyleProperty); }
            set { this.SetValue(OldValueStyleProperty, value); }
        }

        public Style ErrorStyle
        {
            get { return (Style)this.GetValue(ErrorStyleProperty); }
            set { this.SetValue(ErrorStyleProperty, value); }
        }

        private static void OnPartStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Row)d).UpdateTemplate();
        }
    }

    public partial class ContentRow
    {
        public static readonly DependencyProperty ControlTemplateSelectorProperty = DependencyProperty.Register(
            nameof(ControlTemplateSelector),
            typeof(RowControlTemplateSelector),
            typeof(ContentRow),
            new PropertyMetadata(
               default(RowControlTemplateSelector),
               OnPartStyleChanged));

        public static readonly DependencyProperty HeaderStyleProperty = PropertyGrid.HeaderStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public static readonly DependencyProperty ValueStyleProperty = PropertyGrid.ValueStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public static readonly DependencyProperty SuffixStyleProperty = PropertyGrid.SuffixStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public static readonly DependencyProperty OldValueStyleProperty = PropertyGrid.OldValueStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public static readonly DependencyProperty ErrorStyleProperty = PropertyGrid.ErrorStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        public RowControlTemplateSelector ControlTemplateSelector
        {
            get { return (RowControlTemplateSelector)this.GetValue(ControlTemplateSelectorProperty); }
            set { this.SetValue(ControlTemplateSelectorProperty, value); }
        }

        public Style HeaderStyle
        {
            get { return (Style)this.GetValue(HeaderStyleProperty); }
            set { this.SetValue(HeaderStyleProperty, value); }
        }

        public Style ValueStyle
        {
            get { return (Style)this.GetValue(ValueStyleProperty); }
            set { this.SetValue(ValueStyleProperty, value); }
        }

        public Style SuffixStyle
        {
            get { return (Style)this.GetValue(SuffixStyleProperty); }
            set { this.SetValue(SuffixStyleProperty, value); }
        }

        public Style OldValueStyle
        {
            get { return (Style)this.GetValue(OldValueStyleProperty); }
            set { this.SetValue(OldValueStyleProperty, value); }
        }

        public Style ErrorStyle
        {
            get { return (Style)this.GetValue(ErrorStyleProperty); }
            set { this.SetValue(ErrorStyleProperty, value); }
        }

        private static void OnPartStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ContentRow)d).UpdateTemplate();
        }
    }
}
