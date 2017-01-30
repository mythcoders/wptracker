using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Windows.Storage.Streams;
using Windows.Storage;
using System.IO.IsolatedStorage;
using WPTracker.Data;

namespace WPTracker.Settings
{
    public partial class Update : PhoneApplicationPage
    {      
        public Update(MobileServiceCollection<OSVersions, OSVersions> osItems, MobileServiceCollection<Phones, Phones> phoneItems)
        {
            _osItems = osItems;
            _phoneItems = phoneItems;
            InitializeComponent();

            var applicationSettings = new AppSettings();
            offlineDataDateTB.Text = "offline data last updated: " + applicationSettings.DatabaseLastUpdateSetting;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            progressBar1.IsEnabled = true;
            progressBar1.IsIndeterminate = true;

            UpdateData();
        }

        #region Actual Updating

        #region Database Tables
        private MobileServiceCollection<Phones, Phones> _phoneItems;
        private readonly IMobileServiceTable<Phones> _phoneTable =
            App.MobileService.GetTable<Phones>();

        private MobileServiceCollection<OSVersions, Data.OSVersions> _osItems;
        private readonly IMobileServiceTable<OSVersions> _osTable =
            App.MobileService.GetTable<OSVersions>();
        #endregion

        IEnumerable<Phones> _phoneList = new List<Phones>();
        IEnumerable<OSVersions> _osList = new List<OSVersions>();

        public void UpdateData()
        {
            UpdatePhones();
        }         

        public async void UpdatePhones()
        {
            const string fileName = "phones.json";

            //Query Phones
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

            //Write Phones
            var jsonContents = JsonConvert.SerializeObject(_phoneList);
            var localFolder = ApplicationData.Current.LocalFolder;
            var textFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            using (var textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var textWriter = new DataWriter(textStream))
                {
                    textWriter.WriteString(jsonContents); await textWriter.StoreAsync();
                }
            }

            UpdateOSVersions();
        }

        public async void UpdateOSVersions()
        {
            const string fileName = "os.json";

            //Query OS Versions
            try
            {
                _osList = await _osTable
                .Where(oSItem => oSItem.Publish == true)
                .OrderBy(oSItem => oSItem.SortOrder)
                .ToListAsync();
            }
            catch (MobileServiceInvalidOperationException f)
            {
                MessageBox.Show(f.Response.Content.ToString(),
                        string.Format("{0} (HTTP {1})",
                        f.Response.Content,
                        f.Response.StatusCode), MessageBoxButton.OK);
            }

            //Write OS Version
            var jsonContents = JsonConvert.SerializeObject(_osList);
            var localFolder = ApplicationData.Current.LocalFolder;
            var textFile = await localFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            using (var textStream = await textFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var textWriter = new DataWriter(textStream))
                {
                    textWriter.WriteString(jsonContents); await textWriter.StoreAsync();
                }
            }

            UpdateUpdateData();
        }
        

        #endregion

        public void UpdateUpdateData()
        {
            var date = DateTime.Today.Day.ToString();
            var month = DateTime.Today.Month.ToString();
            var year = DateTime.Today.Year.ToString();

            var fullDate = month + "/" + date + "/" + year;

            var applicationSettings = new AppSettings {DatabaseLastUpdateSetting = fullDate};

            MessageBox.Show("Offline data has been updated.", "Success!", MessageBoxButton.OK);

            offlineDataDateTB.Text = "offline data last updated: " + applicationSettings.DatabaseLastUpdateSetting;
            progressBar1.IsEnabled = false;
            progressBar1.Visibility = Visibility.Collapsed;
            progressBar1.IsIndeterminate = false;
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var applicationSettings = new AppSettings();
            
            const string phoneFileName = "phones.json"; 
            const string osFileName = "os.json";

            using (var myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(phoneFileName))
                {
                    myIsolatedStorage.DeleteFile(phoneFileName);
                }
            }

            using (var myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (myIsolatedStorage.FileExists(osFileName))
                {
                    myIsolatedStorage.DeleteFile(osFileName);
                }
            }
            
            MessageBox.Show("Offline data has been deleted.", "Success!", MessageBoxButton.OK);

            applicationSettings.DatabaseLastUpdateSetting = "Never";
            offlineDataDateTB.Text = "offline data last updated: " + applicationSettings.DatabaseLastUpdateSetting;
        }
    }
}