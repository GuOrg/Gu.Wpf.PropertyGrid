#pragma warning disable SA1402 // File may only contain a single class
namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class PropertyGrid
    {
        /// <summary>Identifies the HeaderStyle attached dependency property.</summary>
        public static readonly DependencyProperty HeaderStyleProperty = DependencyProperty.RegisterAttached(
            "HeaderStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueStyle attached dependency property.</summary>
        public static readonly DependencyProperty ValueStyleProperty = DependencyProperty.RegisterAttached(
            "ValueStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixStyle attached dependency property.</summary>
        public static readonly DependencyProperty SuffixStyleProperty = DependencyProperty.RegisterAttached(
            "SuffixStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the OldValueStyle attached dependency property.</summary>
        public static readonly DependencyProperty OldValueStyleProperty = DependencyProperty.RegisterAttached(
            "OldValueStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ErrorStyle attached dependency property.</summary>
        public static readonly DependencyProperty ErrorStyleProperty = DependencyProperty.RegisterAttached(
            "ErrorStyle",
            typeof(Style),
            typeof(PropertyGrid),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Helper for setting HeaderStyle property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set HeaderStyle property on.</param>
        /// <param name="value">HeaderStyle property value.</param>
        public static void SetHeaderStyle(this UIElement element, Style value)
        {
            element.SetValue(HeaderStyleProperty, value);
        }

        /// <summary>
        /// Helper for reading HeaderStyle property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read HeaderStyle property from.</param>
        /// <returns>HeaderStyle property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetHeaderStyle(this UIElement element)
        {
            return (Style)element.GetValue(HeaderStyleProperty);
        }

        /// <summary>
        /// Helper for setting ValueStyle property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set ValueStyle property on.</param>
        /// <param name="value">ValueStyle property value.</param>
        public static void SetValueStyle(this UIElement element, Style value)
        {
            element.SetValue(ValueStyleProperty, value);
        }

        /// <summary>
        /// Helper for reading ValueStyle property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read ValueStyle property from.</param>
        /// <returns>ValueStyle property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetValueStyle(this UIElement element)
        {
            return (Style)element.GetValue(ValueStyleProperty);
        }

        /// <summary>
        /// Helper for setting SuffixStyle property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set SuffixStyle property on.</param>
        /// <param name="value">SuffixStyle property value.</param>
        public static void SetSuffixStyle(this UIElement element, Style value)
        {
            element.SetValue(SuffixStyleProperty, value);
        }

        /// <summary>
        /// Helper for reading SuffixStyle property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read SuffixStyle property from.</param>
        /// <returns>SuffixStyle property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetSuffixStyle(this UIElement element)
        {
            return (Style)element.GetValue(SuffixStyleProperty);
        }

        /// <summary>
        /// Helper for setting OldValueStyle property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set OldValueStyle property on.</param>
        /// <param name="value">OldValueStyle property value.</param>
        public static void SetOldValueStyle(this UIElement element, Style value)
        {
            element.SetValue(OldValueStyleProperty, value);
        }

        /// <summary>
        /// Helper for reading OldValueStyle property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read OldValueStyle property from.</param>
        /// <returns>OldValueStyle property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetOldValueStyle(this UIElement element)
        {
            return (Style)element.GetValue(OldValueStyleProperty);
        }

        /// <summary>
        /// Helper for setting ErrorStyle property on a UIElement.
        /// </summary>
        /// <param name="element">UIElement to set ErrorStyle property on.</param>
        /// <param name="value">ErrorStyle property value.</param>
        public static void SetErrorStyle(this UIElement element, Style value)
        {
            element.SetValue(ErrorStyleProperty, value);
        }

        /// <summary>
        /// Helper for reading ErrorStyle property from a UIElement.
        /// </summary>
        /// <param name="element">UIElement to read ErrorStyle property from.</param>
        /// <returns>ErrorStyle property value.</returns>
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetErrorStyle(this UIElement element)
        {
            return (Style)element.GetValue(ErrorStyleProperty);
        }
    }

    public partial class Rows
    {
        /// <summary>Identifies the HeaderStyle dependency property.</summary>
        public static readonly DependencyProperty HeaderStyleProperty = PropertyGrid.HeaderStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ValueStyle dependency property.</summary>
        public static readonly DependencyProperty ValueStyleProperty = PropertyGrid.ValueStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the SuffixStyle dependency property.</summary>
        public static readonly DependencyProperty SuffixStyleProperty = PropertyGrid.SuffixStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the OldValueStyle dependency property.</summary>
        public static readonly DependencyProperty OldValueStyleProperty = PropertyGrid.OldValueStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>Identifies the ErrorStyle dependency property.</summary>
        public static readonly DependencyProperty ErrorStyleProperty = PropertyGrid.ErrorStyleProperty.AddOwner(
            typeof(Rows),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Gets or sets the HeaderStyle.
        /// </summary>
        public Style HeaderStyle
        {
            get { return (Style)this.GetValue(HeaderStyleProperty); }
            set { this.SetValue(HeaderStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ValueStyle.
        /// </summary>
        public Style ValueStyle
        {
            get { return (Style)this.GetValue(ValueStyleProperty); }
            set { this.SetValue(ValueStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the SuffixStyle.
        /// </summary>
        public Style SuffixStyle
        {
            get { return (Style)this.GetValue(SuffixStyleProperty); }
            set { this.SetValue(SuffixStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the OldValueStyle.
        /// </summary>
        public Style OldValueStyle
        {
            get { return (Style)this.GetValue(OldValueStyleProperty); }
            set { this.SetValue(OldValueStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ErrorStyle.
        /// </summary>
        public Style ErrorStyle
        {
            get { return (Style)this.GetValue(ErrorStyleProperty); }
            set { this.SetValue(ErrorStyleProperty, value); }
        }
    }

    public abstract partial class Row
    {
        /// <summary>Identifies the HeaderStyle dependency property.</summary>
        public static readonly DependencyProperty HeaderStyleProperty = PropertyGrid.HeaderStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>Identifies the ValueStyle dependency property.</summary>
        public static readonly DependencyProperty ValueStyleProperty = PropertyGrid.ValueStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>Identifies the SuffixStyle dependency property.</summary>
        public static readonly DependencyProperty SuffixStyleProperty = PropertyGrid.SuffixStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>Identifies the OldValueStyle dependency property.</summary>
        public static readonly DependencyProperty OldValueStyleProperty = PropertyGrid.OldValueStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>Identifies the ErrorStyle dependency property.</summary>
        public static readonly DependencyProperty ErrorStyleProperty = PropertyGrid.ErrorStyleProperty.AddOwner(
            typeof(Row),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>
        /// Gets or sets the HeaderStyle.
        /// </summary>
        public Style HeaderStyle
        {
            get { return (Style)this.GetValue(HeaderStyleProperty); }
            set { this.SetValue(HeaderStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ValueStyle.
        /// </summary>
        public Style ValueStyle
        {
            get { return (Style)this.GetValue(ValueStyleProperty); }
            set { this.SetValue(ValueStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the SuffixStyle.
        /// </summary>
        public Style SuffixStyle
        {
            get { return (Style)this.GetValue(SuffixStyleProperty); }
            set { this.SetValue(SuffixStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the OldValueStyle.
        /// </summary>
        public Style OldValueStyle
        {
            get { return (Style)this.GetValue(OldValueStyleProperty); }
            set { this.SetValue(OldValueStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ErrorStyle.
        /// </summary>
        public Style ErrorStyle
        {
            get { return (Style)this.GetValue(ErrorStyleProperty); }
            set { this.SetValue(ErrorStyleProperty, value); }
        }

        private static void OnPartStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }

    public partial class ContentRow
    {
        /// <summary>Identifies the HeaderStyle dependency property.</summary>
        public static readonly DependencyProperty HeaderStyleProperty = PropertyGrid.HeaderStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>Identifies the ValueStyle dependency property.</summary>
        public static readonly DependencyProperty ValueStyleProperty = PropertyGrid.ValueStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>Identifies the SuffixStyle dependency property.</summary>
        public static readonly DependencyProperty SuffixStyleProperty = PropertyGrid.SuffixStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>Identifies the OldValueStyle dependency property.</summary>
        public static readonly DependencyProperty OldValueStyleProperty = PropertyGrid.OldValueStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>Identifies the ErrorStyle dependency property.</summary>
        public static readonly DependencyProperty ErrorStyleProperty = PropertyGrid.ErrorStyleProperty.AddOwner(
            typeof(ContentRow),
            new FrameworkPropertyMetadata(
                default(Style),
                FrameworkPropertyMetadataOptions.Inherits,
                OnPartStyleChanged));

        /// <summary>
        /// Gets or sets the HeaderStyle.
        /// </summary>
        public Style HeaderStyle
        {
            get { return (Style)this.GetValue(HeaderStyleProperty); }
            set { this.SetValue(HeaderStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ValueStyle.
        /// </summary>
        public Style ValueStyle
        {
            get { return (Style)this.GetValue(ValueStyleProperty); }
            set { this.SetValue(ValueStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the SuffixStyle.
        /// </summary>
        public Style SuffixStyle
        {
            get { return (Style)this.GetValue(SuffixStyleProperty); }
            set { this.SetValue(SuffixStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the OldValueStyle.
        /// </summary>
        public Style OldValueStyle
        {
            get { return (Style)this.GetValue(OldValueStyleProperty); }
            set { this.SetValue(OldValueStyleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the ErrorStyle.
        /// </summary>
        public Style ErrorStyle
        {
            get { return (Style)this.GetValue(ErrorStyleProperty); }
            set { this.SetValue(ErrorStyleProperty, value); }
        }

        private static void OnPartStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
