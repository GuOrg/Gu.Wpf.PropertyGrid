namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public class RowInfoPresenter : Control
    {
        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register(
            "Target",
            typeof(Row),
            typeof(RowInfoPresenter),
            new PropertyMetadata(default(Row)));

        static RowInfoPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RowInfoPresenter), new FrameworkPropertyMetadata(typeof(RowInfoPresenter)));
            FocusableProperty.OverrideMetadataWithDefaultValue(typeof(RowInfoPresenter), false);
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
