using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Windows;
using Windows.Storage;
using Windows.Storage.Streams;

namespace WPTracker.Helpers
{
    public class UpdateDatabase
    {
        #region Database Tables
        
        private readonly IMobileServiceTable<Data.Phones> _phoneTable = App.MobileService.GetTable<Data.Phones>();
        private readonly IMobileServiceTable<Data.OSVersions> _osTable = App.MobileService.GetTable<Data.OSVersions>();

        #endregion

        IEnumerable<Data.Phones> _phoneList = new List<Data.Phones>();
        IEnumerable<Data.OSVersions> _osList = new List<Data.OSVersions>();

        bool _silentlyUpdateData;

        public void UpdateData(bool silentUpdate)
        {
            UpdatePhones();
            _silentlyUpdateData = silentUpdate;
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
                .Where(OSItem => OSItem.Publish == true)
                .OrderBy(OSItem => OSItem.SortOrder)
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

        public void UpdateUpdateData()
        {
            var applicationSettings = new AppSettings {DatabaseLastUpdateSetting = DateTime.Now.ToString("d")};

            if (_silentlyUpdateData == false)
            {
                MessageBox.Show("Offline database has been updated.", "Success!", MessageBoxButton.OK);
            }
        }
    }
}
