using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Navigation;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Windows.Threading;
using Telerik.Windows.Data;
using Telerik.Windows.Controls;
using Windows.Storage;
using Windows.Storage.Streams;

namespace WPTracker.Views.OS
{
    public partial class OSMainVIew
    {
        private MobileServiceCollection<Data.OSVersions, WPTracker.Data.OSVersions> items;
        private readonly IMobileServiceTable<Data.OSVersions> _osTable =
            App.MobileService.GetTable<Data.OSVersions>();

        private ObservableCollection<Data.OSVersions> _source = new ObservableCollection<Data.OSVersions>();
        private readonly DispatcherTimer timer;

        List<Data.OSVersions> _osList = null;
        private const string FileName = "os.json";

        public OSMainVIew()
        {
            InitializeComponent();

            var branches = new string[] { "Windows Phone 7", "Windows Phone 7.5", "Windows Phone 7.8", "Windows Phone 8", "Windows Phone 8.?"};
                        
            var groupPickerItems = new List<string>(32);
            groupPickerItems.AddRange(branches);

            var groupByBranch = new GenericGroupDescriptor<WPTracker.Data.OSVersions, string>(version => version.Branch);
            RadJumpList1.GroupDescriptors.Add(groupByBranch);

            timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(2)};
            timer.Tick += (object sender, EventArgs args) =>
                {

                };

            RadJumpList1.GroupHeaderItemTap += this.OnGroupHeader_ItemTap;
            RadJumpList1.DataRequested += this.jumpList_DataRequested;
            RadJumpList1.GroupPickerItemTap += this.radJumpList_GroupPickerItemTap;
            LoadData();
            RadJumpList1.ItemTap += this.OnJumpList_ItemTap;

            var settings = new WPTracker.AppSettings();

            if (settings.OfflineDataSetting == true)
            {
                GetSavedData();
            }
            else
            {
                GetFreshData();
            }
        }

        public async void GetSavedData()
        {
            progressBar1.IsEnabled = false;
            progressBar1.Visibility = Visibility.Collapsed;
            progressBar1.IsIndeterminate = false;

            var localFolder = ApplicationData.Current.LocalFolder;

            try
            {
                var textFile = await localFolder.GetFileAsync(FileName);
                using (IRandomAccessStream textStream = await textFile.OpenReadAsync())
                {
                    using (var textReader = new DataReader(textStream))
                    {
                        var textLength = (uint)textStream.Size;
                        await textReader.LoadAsync(textLength);
                        var jsonContents = textReader.ReadString(textLength);
                        _osList = JsonConvert.DeserializeObject<IList<Data.OSVersions>>(jsonContents) as List<Data.OSVersions>;
                        RadJumpList1.ItemsSource = _osList;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("For some reason, there was an error loading the offline data. Don't worry, we'll go ahead and download you a fresh copy now. " + ex, "Error loading offline data", MessageBoxButton.OK);

                var updateDatabase = new Helpers.UpdateDatabase();
                updateDatabase.UpdateData(false);
            }
        }

        private async void GetFreshData()
        {
            progressBar1.IsEnabled = true;
            progressBar1.IsIndeterminate = true;

            try
            {
                items = await _osTable
                .Where(osItem => osItem.Publish == true)
                .OrderBy(osItem => osItem.SortOrder)
                .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException f)
            {
                MessageBox.Show(f.Response.Content.ToString(),
                        string.Format("{0} (HTTP {1})",
                        f.Response.Content,
                        f.Response.StatusCode), MessageBoxButton.OK);
            }

            this.RadJumpList1.ItemsSource = items;

            progressBar1.IsEnabled = false;
            progressBar1.Visibility = Visibility.Collapsed;
            progressBar1.IsIndeterminate = false;
        }

        private void jumpList_DataRequested(object sender, EventArgs e)
        {
            if (!timer.IsEnabled)
            {
                timer.Start();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var settings = new AppSettings();

            if (settings.OfflineDataSetting)
            {
                GetSavedData();
            }
            else
            {
                GetFreshData();
            }
        } 

        private void OnJumpList_ItemTap(object sender, ListBoxItemTapEventArgs args)
        {
            App.SelectedVersion = RadJumpList1.SelectedItem as Data.OSVersions;
            NavigationService.Navigate(new Uri("/Views/OS/OSItemView.xaml", UriKind.Relative));
        }

        private void LoadData()
        {
            timer.Stop();
        }

        private void OnGroupHeader_ItemTap(object sender, GroupHeaderItemTapEventArgs e)
        {
            //Unkown
        }

        private void radJumpList_GroupPickerItemTap(object sender, GroupPickerItemTapEventArgs e)
        {
            foreach (var @group in this.RadJumpList1.Groups.Where(@group => @group.Key.ToString().ToLower() == e.DataItem.ToString().ToLower()))
            {
                e.DataItemToNavigate = @group;
                return;
            }

            e.ClosePicker = false;
        }
    }
}