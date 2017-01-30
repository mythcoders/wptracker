using System.Linq;
using Telerik.Windows.Controls;
using System.Windows;
using Telerik.Windows.Controls.JumpList;

namespace WPTracker
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

        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            if (this.groupPicker == null)
            {
                this.groupPicker = ElementTreeHelper.FindVisualAncestor<JumpListGroupPicker>(container);
            }

            return this.IsItemLinked(item) ? this.NormalGroupTemplate : this.DisabledGroupTemplate;
        }

        private bool IsItemLinked(object item)
        {
            return groupPicker.Owner.Groups.Any(@group => @group.Key.ToString().ToLower() == item.ToString().ToLower());
        }
    }
}
