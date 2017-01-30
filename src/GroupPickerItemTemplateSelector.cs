using System;
using Telerik.Windows.Controls;
using System.Windows;
using Telerik.Windows.Controls.JumpList;
using Telerik.Windows.Data;

namespace WP7_Tracker
{
    public class GroupPickerItemTemplateSelector : DataTemplateSelector
    {
        private JumpListGroupPicker groupPicker;

        public DataTemplate DisabledGroupTemplate
        {
            get;
            set;
        }

        public DataTemplate NormalGroupTemplate
        {
            get;
            set;
        }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (this.groupPicker == null)
            {
                this.groupPicker = ElementTreeHelper.FindVisualAncestor<JumpListGroupPicker>(container);
            }

            return this.IsItemLinked(item) ? this.NormalGroupTemplate : this.DisabledGroupTemplate;
        }

        private bool IsItemLinked(object item)
        {
            foreach (DataGroup group in this.groupPicker.Owner.Groups)
            {
                if (group.Key.ToString().ToLower() == item.ToString().ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
