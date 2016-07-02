namespace Gu.Wpf.PropertyGrid
{
    using System.Windows;
    using System.Windows.Controls;

    public class RowControlTemplateSelector : ControlTemplateSelector<Row>
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
            get
            {
                return this.plainTemplate;
            }

            set
            {
                AssertIsValidTemplate(value);
                this.plainTemplate = value;
            }
        }

        public ControlTemplate InfoTemplate
        {
            get
            {
                return this.infoTemplate;
            }

            set
            {
                AssertIsValidTemplate(value);
                this.infoTemplate = value;
            }
        }

        public ControlTemplate TextBoxHeaderTemplate
        {
            get
            {
                return this.textBoxHeaderTemplate;
            }

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxHeaderTemplate = value;
            }
        }

        public ControlTemplate TextBoxHeaderAndInfoTemplate
        {
            get
            {
                return this.textBoxHeaderAndInfoTemplate;
            }

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxHeaderAndInfoTemplate = value;
            }
        }

        public ControlTemplate TextBoxSuffixTemplate
        {
            get
            {
                return this.textBoxSuffixTemplate;
            }

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxSuffixTemplate = value;
            }
        }

        public ControlTemplate TextBoxSuffixInfoTemplate
        {
            get
            {
                return this.textBoxSuffixInfoTemplate;
            }

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxSuffixInfoTemplate = value;
            }
        }

        public ControlTemplate TextBoxHeaderAndSuffixTemplate
        {
            get
            {
                return this.textBoxHeaderAndSuffixTemplate;
            }

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxHeaderAndSuffixTemplate = value;
            }
        }

        public ControlTemplate TextBoxHeaderAndSuffixAndInfoTemplate
        {
            get
            {
                return this.textBoxHeaderAndSuffixAndInfoTemplate;
            }

            set
            {
                AssertIsValidTemplate(value);
                this.textBoxHeaderAndSuffixAndInfoTemplate = value;
            }
        }

        protected override ControlTemplate SelectTemplate(Row container)
        {
            if (container.InfoPresenterStyle == null)
            {
                if (IsTextBlockStyle(container.HeaderStyle) && IsTextBlockStyle(container.SuffixStyle))
                {
                    return this.plainTemplate;
                }

                if (IsTextBoxStyle(container.HeaderStyle) && IsTextBlockStyle(container.SuffixStyle))
                {
                    return this.textBoxHeaderTemplate;
                }

                if (IsTextBoxStyle(container.HeaderStyle) && IsTextBoxStyle(container.SuffixStyle))
                {
                    return this.textBoxHeaderAndSuffixTemplate;
                }

                return this.textBoxSuffixTemplate;
            }
            else
            {
                if (IsTextBlockStyle(container.HeaderStyle) && IsTextBlockStyle(container.SuffixStyle))
                {
                    return this.infoTemplate;
                }

                if (IsTextBoxStyle(container.HeaderStyle) && IsTextBlockStyle(container.SuffixStyle))
                {
                    return this.textBoxHeaderAndInfoTemplate;
                }

                if (IsTextBoxStyle(container.HeaderStyle) && IsTextBoxStyle(container.SuffixStyle))
                {
                    return this.textBoxHeaderAndSuffixAndInfoTemplate;
                }

                return this.textBoxSuffixInfoTemplate;
            }
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
    }
}