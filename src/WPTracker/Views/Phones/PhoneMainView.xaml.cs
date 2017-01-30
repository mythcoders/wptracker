using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using Windows.Storage;
using Windows.Storage.Streams;

namespace WPTracker.ViewModels.Phones
{
    public partial class PhoneMainView : PhoneApplicationPage
    {
        private MobileServiceCollection<Data.Phones, Data.Phones> items;                
        private readonly IMobileServiceTable<Data.Phones> _phoneTable =
            App.MobileService.GetTable<Data.Phones>();

        private ObservableCollection<Data.Phones> _source = new ObservableCollection<Data.Phones>();        
        private readonly DispatcherTimer timer;

        List<Data.Phones> _phoneList = null;
        private const string FileName = "phones.json";

        public PhoneMainView()
        {
            #region Loading Junk...
            InitializeComponent();
            App.SelectedPhone = null;

            GenericGroupDescriptor<WPTracker.Data.Phones, string>
                groupByFirstName = new GenericGroupDescriptor<WPTracker.Data.Phones, string>(device => device.Make);
            this.radJumpList1.GroupDescriptors.Add(groupByFirstName);
            
            this.timer = new DispatcherTimer();
            this.timer.Interval = TimeSpan.FromSeconds(2);
            this.timer.Tick += (object sender, EventArgs args) =>
            {

            };

            this.radJumpList1.GroupHeaderItemTap += this.OnGroupHeader_ItemTap;
            this.radJumpList1.DataRequested += this.jumpList_DataRequested;
            this.radJumpList1.GroupPickerItemTap += this.radJumpList_GroupPickerItemTap;            
            this.LoadData();
            this.radJumpList1.ItemTap += this.OnJumpList_ItemTap;

            var settings = new WPTracker.AppSettings();

            if (settings.OfflineDataSetting == true)
            {
                GetSavedData();
            }
            else
            {
                GetFreshData();
            }

            #endregion
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
                        uint textLength = (uint)textStream.Size;
                        await textReader.LoadAsync(textLength);
                        string jsonContents = textReader.ReadString(textLength);
                        _phoneList = JsonConvert.DeserializeObject<IList<Data.Phones>>(jsonContents) as List<Data.Phones>;
                        radJumpList1.ItemsSource = _phoneList;            
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("For some reason, there was an error loading the offline data. Don't worry, we'll go ahead and download you a fresh copy now. " + ex, "Error loading offline data", MessageBoxButton.OK);

                var updateDatabase = new WPTracker.Helpers.UpdateDatabase();
                updateDatabase.UpdateData(false);
            }
        }

        public async void GetFreshData()
        {            
            progressBar1.IsEnabled = true;
            progressBar1.IsIndeterminate = true;

            try
            {
                _phoneList = await _phoneTable
                    .Where(phoneItem => phoneItem.Publish == true)
                    .OrderBy(phoneItem => phoneItem.FullName)
                    .ToListAsync();
            }
            catch (MobileServiceInvalidOperationException f)
            {
                MessageBox.Show(f.Response.Content.ToString(),
                        string.Format("{0} (HTTP {1})",
                        f.Response.Content,
                        f.Response.StatusCode), MessageBoxButton.OK);
            }

            radJumpList1.ItemsSource = _phoneList;
            radJumpList1.StopPullToRefreshLoading(true);

            progressBar1.IsEnabled = false;
            progressBar1.Visibility = Visibility.Collapsed;
            progressBar1.IsIndeterminate = false;
        }

        private void radJumpList_GroupPickerItemTap(object sender, GroupPickerItemTapEventArgs e)
        {
            foreach (var @group in this.radJumpList1.Groups.Where(@group => @group.Key.ToString().ToLower() == e.DataItem.ToString().ToLower()))
            {
                e.DataItemToNavigate = @group;
                return;
            }

            e.ClosePicker = false;
        }

        private void LoadData()
        {
            timer.Stop();            
        }

        private void jumpList_DataRequested(object sender, EventArgs e)
        {
            if (!timer.IsEnabled)
            {
                timer.Start();
            }
        }

        private void OnGroupHeader_ItemTap(object sender, GroupHeaderItemTapEventArgs e)
        {
           
        }

        private void OnJumpList_ItemTap(object sender, ListBoxItemTapEventArgs args)
        {
            App.SelectedPhone = radJumpList1.SelectedItem as WPTracker.Data.Phones;
            NavigationService.Navigate(new Uri("/Views/Phones/PhoneItemView.xaml", UriKind.Relative));
        }

        private void radJumpList1_RefreshRequested(object sender, EventArgs e)
        {
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

        private async void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            var devicePublicName = App.MyDevice;

            //TODO: Read from XML not Azure

            try
            {
                items = await _phoneTable
                    .Where(phone => phone.Model == devicePublicName)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException f)
            {
                MessageBox.Show(f.Response.Content.ToString(),
                        string.Format("{0} (HTTP {1})",
                        f.Response.Content,
                        f.Response.StatusCode), MessageBoxButton.OK);
            }

            this.radJumpList1.ItemsSource = items;
        }

        private void ApplicationBarMenuItem_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings/DeviceSpecs.xaml", UriKind.Relative));
        }           
    }
}