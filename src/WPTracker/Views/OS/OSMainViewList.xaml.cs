using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Windows.Threading;
using Telerik.Windows.Data;
using Telerik.Windows.Controls;
using System.Windows.Navigation;
using System.Collections.ObjectModel;

namespace WPTracker.ViewModels.OS
{
    public partial class OSMainViewList : PhoneApplicationPage
    {
        private MobileServiceCollection<OSVersions, OSVersions> items;
        private IMobileServiceTable<OSVersions> osTable =
            App.MobileService.GetTable<OSVersions>();

        private ObservableCollection<OSVersions> source = new ObservableCollection<OSVersions>();
        private DispatcherTimer timer;
        
        public OSMainViewList()
        {
            InitializeComponent();

            string[] branches = new string[] { "Windows Phone 7", "Windows Phone 7.5", "Windows Phone 7.8", "Windows Phone 8", "Windows Phone 8.?" };

            List<string> groupPickerItems = new List<string>(32);
            groupPickerItems.AddRange(branches);

            GenericGroupDescriptor<OSVersions, string>
                groupByBranch = new GenericGroupDescriptor<OSVersions, string>(version => version.Branch);

            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(2);
            this.timer.Tick += (object sender, EventArgs args) =>
                {

                };
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RefreshOSItems();
        } 

        private async void RefreshOSItems()
        {
            progressBar1.IsEnabled = true;
            progressBar1.IsIndeterminate = true;

            try
            {
                items = await osTable
                .Where(OSItem => OSItem.Publish == true)
                .OrderBy(OSItem => OSItem.SortOrder)
                .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException)
            {
                MessageBox.Show("Error", "Error", MessageBoxButton.OK);
            }

            this.radDataBoundListBox.ItemsSource = items;

            progressBar1.IsEnabled = false;
            progressBar1.Visibility = System.Windows.Visibility.Collapsed;
            progressBar1.IsIndeterminate = false;
        }
    }
}
