using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;
using Microsoft.Phone.Tasks;

namespace WPTracker
{
    public partial class DataChanges : PhoneApplicationPage
    {
        string _dbVersion = String.Empty;
        
        public DataChanges()
        {
            InitializeComponent();
            GetDBVersion();

            var tableNames = new List<string>() {
            "Phones",
            "Operating Systems",
            "Regions",
            "Carriers",
            "Database/App Changes",
        };

            tablePicker.ItemsSource = tableNames;
        }

        public async void GetDBVersion()
        {
            try
            {
                IEnumerable<Data.Database> results = await App.MobileService.InvokeApiAsync <IEnumerable<Data.Database>>(
                    "getdbversion", HttpMethod.Get, null
                    );

                foreach (var item in results)
                {
                    _dbVersion = item.Version;
                }
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                var message = ex.Message;
                _dbVersion = "Unknown";
            }
        }

        private void sendChanges_Click(object sender, RoutedEventArgs e)
        {
            //Field is passed to the DB like: <tableName>.<fieldName> EX: Phones.Weight
            string field = tablePicker.SelectedValue.ToString() + "." + fieldTB.Text;
            string oldValue = oldValueTB.Text;
            string newValue = newValueTB.Text;
            string version = _dbVersion;

            var emailComposeTask = new EmailComposeTask
            {
                Subject = "[WPTracker] Content Changes",
                To = "support@adkinssd.com",
                Body =
                    "Field: " + field + "\nOldValue: " + oldValue + "\nNewValue: " + newValue + "\nDatabase " + version
            };

            emailComposeTask.Show();
        }
    }
}