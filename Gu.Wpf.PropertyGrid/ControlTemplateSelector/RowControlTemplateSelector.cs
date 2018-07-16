#pragma warning disable WPF1011
namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

#pragma warning disable INPC001 // Implement INotifyPropertyChanged.
    public class RowControlTemplateSelector : ControlTemplateSelector<Row>
#pragma warning restore INPC001 // Implement INotifyPropertyChanged.
    {
        private ControlTemplate textBoxHeaderTemplate;
        private ControlTemplate textBoxHeaderAndSuffixTemplate;
        private ControlTemplate textBoxHeaderAndInfoTemplate;
        private ControlTemplate plainTemplate;
        private ControlTemplate infoTemplate;
        private ControlTemplate textBoxHeaderAndSuffixAndInfoTemplate;
        private ControlTemplate textBoxSuffixTemplate;
        private ControlTemplate textBoxSuffixInfoTemplate;

        public ControlTemplate PlainTemplate
        {
            get => this.plainTemplate;

            set
            {
                AssertIsValidTemplate(value);
                this.plainTemplate = value;
            }
        }

        public ControlTemplate InfoTemplate
        {
            get => this.infoTemplate;

            set
            {
                AssertIsValidTemplate(value);
                this.infoTemplate = value;
            }
        }

        public ControlTemplate TextBoxHeaderTemplate
        {
            get => this.textBoxHeaderTemplate;

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxHeaderTemplate = value;
            }
        }

        public ControlTemplate TextBoxHeaderAndInfoTemplate
        {
            get => this.textBoxHeaderAndInfoTemplate;

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxHeaderAndInfoTemplate = value;
            }
        }

        public ControlTemplate TextBoxSuffixTemplate
        {
            get => this.textBoxSuffixTemplate;

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxSuffixTemplate = value;
            }
        }

        public ControlTemplate TextBoxSuffixInfoTemplate
        {
            get => this.textBoxSuffixInfoTemplate;

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxSuffixInfoTemplate = value;
            }
        }

        public ControlTemplate TextBoxHeaderAndSuffixTemplate
        {
            get => this.textBoxHeaderAndSuffixTemplate;

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxHeaderAndSuffixTemplate = value;
            }
        }

        public ControlTemplate TextBoxHeaderAndSuffixAndInfoTemplate
        {
            get => this.textBoxHeaderAndSuffixAndInfoTemplate;

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxHeaderAndSuffixAndInfoTemplate = value;
            }
        }

        public void UpdateCurrentTemplate(ContentRow container)
        {
            container.SetCurrentValue(Control.TemplateProperty, this.SelectTemplateCore(container, container.HeaderStyle, container.SuffixStyle, container.OldValueStyle, container.ErrorStyle));
        }

        protected static bool IsTextBlockStyle(Style style)
        {
            var targetType = style?.TargetType ?? typeof(TextBlock);
            return typeof(TextBlock).IsAssignableFrom(targetType);
        }

        protected static bool IsTextBoxStyle(Style style)
        {
            var targetType = style?.TargetType ?? typeof(ContentPresenter);
            return typeof(TextBox).IsAssignableFrom(targetType);
        }

        protected override ControlTemplate SelectTemplate(Row container)
        {
            return this.SelectTemplateCore(container, container.HeaderStyle, container.SuffixStyle, container.OldValueStyle, container.ErrorStyle);
        }

        // ReSharper disable once UnusedParameter.Global
        protected ControlTemplate SelectTemplateCore(Control container, Style headerStyle, Style suffixStyle, Style oldValueStyle, Style errorStyle)
        {
            if (oldValueStyle == null && errorStyle == null)
            {
                if (IsTextBlockStyle(headerStyle) && IsTextBlockStyle(suffixStyle))
                {
                    return this.plainTemplate;
                }

                if (IsTextBoxStyle(headerStyle) && IsTextBlockStyle(suffixStyle))
                {
                    return this.textBoxHeaderTemplate;
                }

                if (IsTextBoxStyle(headerStyle) && IsTextBoxStyle(suffixStyle))
                {
                    return this.textBoxHeaderAndSuffixTemplate;
                }

                return this.textBoxSuffixTemplate;
            }

            if (IsTextBlockStyle(headerStyle) && IsTextBlockStyle(suffixStyle))
            {
                return this.infoTemplate;
            }

            if (IsTextBoxStyle(headerStyle) && IsTextBlockStyle(suffixStyle))
            {
                return this.textBoxHeaderAndInfoTemplate;
            }

            if (IsTextBoxStyle(headerStyle) && IsTextBoxStyle(suffixStyle))
            {
                return this.textBoxHeaderAndSuffixAndInfoTemplate;
            }

            return this.textBoxSuffixInfoTemplate;
        }
    }
}
