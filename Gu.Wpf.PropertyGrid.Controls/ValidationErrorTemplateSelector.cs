namespace Gu.Wpf.PropertyGrid
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;

    public class ValidationErrorTemplateSelector : DataTemplateSelector, IList
    {
        private readonly List<DataTemplate> templates = new List<DataTemplate>();

        int ICollection.Count => this.templates.Count;

        bool IList.IsFixedSize => ((IList)this.templates).IsFixedSize;

        bool IList.IsReadOnly => ((IList)this.templates).IsReadOnly;

        bool ICollection.IsSynchronized => ((IList)this.templates).IsSynchronized;

        object ICollection.SyncRoot => ((IList)this.templates).SyncRoot;

        object IList.this[int index]
        {
            get { return this.templates[index]; }
            set { this.templates[index] = (DataTemplate)value; }
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return base.SelectTemplate(item, container);
        }

        int IList.Add(object value) => ((IList)this.templates).Add((DataTemplate)value);

        void IList.Clear() => this.templates.Clear();

        bool IList.Contains(object value) => this.templates.Contains((DataTemplate)value);

        void ICollection.CopyTo(Array array, int index) => ((IList)this.templates).CopyTo(array, index);

        IEnumerator IEnumerable.GetEnumerator() => this.templates.GetEnumerator();

        int IList.IndexOf(object value) => ((IList)this.templates).IndexOf((DataTemplate)value);

        void IList.Insert(int index, object value) => ((IList)this.templates).Insert(index, (DataTemplate)value);

        void IList.Remove(object value) => ((IList)this.templates).Remove((DataTemplate)value);

        void IList.RemoveAt(int index) => ((IList)this.templates).RemoveAt(index);
    }
}
