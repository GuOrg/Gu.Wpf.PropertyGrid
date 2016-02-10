namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public class InfoPresenter : Control
    {
        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(
            "Target",
            typeof(SettingControlBase),
            typeof(InfoPresenter),
            new PropertyMetadata(default(SettingControlBase)));

        static InfoPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoPresenter), new FrameworkPropertyMetadata(typeof(InfoPresenter)));
            FocusableProperty.OverrideMetadataWithDefaultValue(typeof(InfoPresenter), false);
        }

        public SettingControlBase Target
        {
            get { return (SettingControlBase)this.GetValue(TargetProperty); }
            set { this.SetValue(TargetProperty, value); }
        }

        protected override void OnInitialized(EventArgs e)
        {
            if (this.Target == null)
            {
                var target = this.Ancestors()
                                 .OfType<SettingControlBase>()
                                 .FirstOrDefault();
                this.SetCurrentValue(TargetProperty, target);
            }

            base.OnInitialized(e);
        }
    }
}
