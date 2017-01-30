using System;
using Microsoft.Phone.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Data;
using WP7_Tracker.ViewModel.Data;

namespace WP7_Tracker.ViewModel
{
    public partial class All : PhoneApplicationPage
    {
        private List<DeviceViewModel> items;
        private ObservableCollection<DeviceViewModel> source = new ObservableCollection<DeviceViewModel>();
        private int lastLoadedIndex = 0;
        private DispatcherTimer timer;

        public All()
        {
            InitializeComponent();
            RadPhoneApplicationFrame frame = App.Current.RootVisual as RadPhoneApplicationFrame;
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            GenericSortDescriptor<DeviceViewModel, string> sortbyName = new GenericSortDescriptor<DeviceViewModel, string>(device => device.Name);
            this.radJumpList1.SortDescriptors.Add(sortbyName);

            List<string> groupPickerItems = new List<string>(32);
            foreach (char c in alphabet)
            {
                groupPickerItems.Add(new string(c, 1));
            }
            this.radJumpList1.GroupPickerItemsSource = groupPickerItems;

            GenericGroupDescriptor<DeviceViewModel, string>
            groupByFirstName = new GenericGroupDescriptor<DeviceViewModel, string>(device => device.Name.Substring(0,1).ToUpper());
            this.radJumpList1.GroupDescriptors.Add(groupByFirstName);
                                  
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(2);
            this.timer.Tick += (object sender, EventArgs args) =>
            {

            };

            this.radJumpList1.GroupHeaderItemTap += this.OnGroupHeader_ItemTap;
            this.radJumpList1.DataRequested += this.jumpList_DataRequested;
            this.radJumpList1.GroupPickerItemTap += this.radJumpList_GroupPickerItemTap;
            this.items = this.GetItems();
            this.LoadData();
            this.radJumpList1.ItemTap += this.OnJumpList_ItemTap;
        }

        private void radJumpList_GroupPickerItemTap(object sender, GroupPickerItemTapEventArgs e)
        {
            foreach (DataGroup group in this.radJumpList1.Groups)
            {
                if (group.Key.ToString().ToLower() == e.DataItem.ToString().ToLower())
                {
                    e.DataItemToNavigate = group;
                    return;
                }
            }

            e.ClosePicker = false;
        }
        
        private void OnJumpList_ItemTap(object sender, ListBoxItemTapEventArgs args)
        {
            string navName = (radJumpList1.SelectedItem as DeviceViewModel).NavName.ToString();
            this.NavigationService.Navigate(new Uri("/" + navName + ".xaml", UriKind.RelativeOrAbsolute));
        }

        private void OnGroupHeader_ItemTap(object sender, GroupHeaderItemTapEventArgs e)
        {
            //Unkown
        }

        private void DisableVirtualization()
        {
            this.radJumpList1.DataVirtualizationMode = DataVirtualizationMode.Automatic;
        }

        private void LoadData()
        {
            this.timer.Stop();
            for (int i = 0; i < 10; i++)
            {
                this.source.Add(this.items[lastLoadedIndex++]);

                if (lastLoadedIndex == this.items.Count)
                {
                    this.DisableVirtualization();
                    break;
                }
            }
        }

        private void jumpList_DataRequested(object sender, EventArgs e)
        {
            if (!this.timer.IsEnabled)
            {
                this.timer.Start();
            }
        }

        private List<DeviceViewModel> GetItems()
        {
            using (XmlReader xmlReader = XmlReader.Create("ViewModel/devices.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<DeviceViewModel>));
                List<DeviceViewModel> devices = deserializer.Deserialize(xmlReader) as List<DeviceViewModel>;

                devices.Sort(
                    new Comparison<DeviceViewModel>((DeviceViewModel d1, DeviceViewModel d2) =>
                    {
                        return d1.Name.CompareTo(d2.Name);
                    }));

                this.radJumpList1.ItemsSource = devices;

                return devices;
            }
        }
    }
}