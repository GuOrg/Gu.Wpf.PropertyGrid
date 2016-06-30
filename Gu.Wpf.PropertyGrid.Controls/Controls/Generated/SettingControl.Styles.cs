#pragma warning disable SA1402 // File may only contain a single class
namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;

    public static partial class SettingControl
    {
        public static readonly DependencyProperty HeaderStyleProperty = DependencyProperty.RegisterAttached(
            "HeaderStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueStyleProperty = DependencyProperty.RegisterAttached(
            "ValueStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixStyleProperty = DependencyProperty.RegisterAttached(
            "SuffixStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty InfoPresenterStyleProperty = DependencyProperty.RegisterAttached(
            "InfoPresenterStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = DependencyProperty.RegisterAttached(
            "OldValueStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = DependencyProperty.RegisterAttached(
            "ErrorStyle",
            typeof(Style),
            typeof(SettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));


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

        public static void SetInfoPresenterStyle(this UIElement element, Style value)
        {
            element.SetValue(InfoPresenterStyleProperty, value);
        }

        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static Style GetInfoPresenterStyle(this UIElement element)
        {
            return (Style)element.GetValue(InfoPresenterStyleProperty);
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

    public abstract partial class SettingControlBase
    {
        public static readonly DependencyProperty HeaderStyleProperty = SettingControl.HeaderStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueStyleProperty = SettingControl.ValueStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixStyleProperty = SettingControl.SuffixStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty InfoPresenterStyleProperty = SettingControl.InfoPresenterStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = SettingControl.OldValueStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = SettingControl.ErrorStyleProperty.AddOwner(
            typeof(SettingControlBase),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));


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

        public Style InfoPresenterStyle
        {
            get { return (Style)this.GetValue(InfoPresenterStyleProperty); }
            set { this.SetValue(InfoPresenterStyleProperty, value); }
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

    public partial class SettingsControl
    {
        public static readonly DependencyProperty HeaderStyleProperty = SettingControl.HeaderStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueStyleProperty = SettingControl.ValueStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixStyleProperty = SettingControl.SuffixStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty InfoPresenterStyleProperty = SettingControl.InfoPresenterStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = SettingControl.OldValueStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = SettingControl.ErrorStyleProperty.AddOwner(
            typeof(SettingsControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));


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

        public Style InfoPresenterStyle
        {
            get { return (Style)this.GetValue(InfoPresenterStyleProperty); }
            set { this.SetValue(InfoPresenterStyleProperty, value); }
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

    public partial class ContentSettingControl
    {
        public static readonly DependencyProperty HeaderStyleProperty = SettingControl.HeaderStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ValueStyleProperty = SettingControl.ValueStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty SuffixStyleProperty = SettingControl.SuffixStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty InfoPresenterStyleProperty = SettingControl.InfoPresenterStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty OldValueStyleProperty = SettingControl.OldValueStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));

        public static readonly DependencyProperty ErrorStyleProperty = SettingControl.ErrorStyleProperty.AddOwner(
            typeof(ContentSettingControl),
            new FrameworkPropertyMetadata(default(Style), FrameworkPropertyMetadataOptions.Inherits));


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

        public Style InfoPresenterStyle
        {
            get { return (Style)this.GetValue(InfoPresenterStyleProperty); }
            set { this.SetValue(InfoPresenterStyleProperty, value); }
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
}

