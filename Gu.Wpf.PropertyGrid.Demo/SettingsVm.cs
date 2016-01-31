namespace Gu.Wpf.PropertyGrid.Demo
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Gu.Units;
    using JetBrains.Annotations;

    public class SettingsVm : INotifyPropertyChanged
    {
        private Length lengthValue = Length.FromMillimetres(12.3456);

        public event PropertyChangedEventHandler PropertyChanged;

        public Length LengthValue
        {
            get { return this.lengthValue; }
            set
            {
                if (value.Equals(this.lengthValue))
                {
                    return;
                }

                this.lengthValue = value;
                this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
