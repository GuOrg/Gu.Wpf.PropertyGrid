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
            typeof(Row),
            typeof(InfoPresenter),
            new PropertyMetadata(default(Row)));

        static InfoPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(InfoPresenter), new FrameworkPropertyMetadata(typeof(InfoPresenter)));
            FocusableProperty.OverrideMetadataWithDefaultValue(typeof(InfoPresenter), false);
        }

        public Row Target
        {
            get { return (Row)this.GetValue(TargetProperty); }
            set { this.SetValue(TargetProperty, value); }
        }

        protected override void OnInitialized(EventArgs e)
        {
            if (this.Target == null)
            {
                var target = this.Ancestors()
                                 .OfType<Row>()
                                 .FirstOrDefault();
                this.SetCurrentValue(TargetProperty, target);
            }

            base.OnInitialized(e);
        }
    }
}
