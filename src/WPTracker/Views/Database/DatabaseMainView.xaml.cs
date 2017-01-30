using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;

namespace WPTracker.Views.Database
{
    public partial class DatabaseMainView : PhoneApplicationPage
    {
        private MobileServiceCollection<Data.Database, Data.Database> items;
        private readonly IMobileServiceTable<Data.Database> _dbTable =
            App.MobileService.GetTable<Data.Database>();

        public DatabaseMainView()
        {
            InitializeComponent();

            this.viewPicker.ItemsSource = changes;
            //this.viewPicker.SelectedItem = 1;
        }

        readonly List<string> changes = new List<string>() {
            "Application",
            "Database",
        };

        private async void viewPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            progressBar1.IsEnabled = true;
            progressBar1.IsIndeterminate = true;

            MainListBox.ItemsSource = null;

            string selectedType = this.viewPicker.SelectedItem.ToString();

            if (selectedType == "Application")
            {
                try
                {
                    items = await _dbTable
                        .Where(dbItem => dbItem.Publish == true)
                        .Where(dbItem => dbItem.Type == "Application")
                        .OrderByDescending(dbItem => dbItem.id)
                        .ToCollectionAsync();
                }
                catch (MobileServiceInvalidOperationException f)
                {
                    MessageBox.Show(f.Response.Content.ToString(),
                        string.Format("{0} (HTTP {1})",
                        f.Response.Content,
                        f.Response.StatusCode), MessageBoxButton.OK);
                }
            }
            else
            {
                try
                {
                    items = await _dbTable
                        .Where(dbItem => dbItem.Publish == true)
                        .Where(dbItem => dbItem.Type == "Database")
                        .OrderByDescending(dbItem => dbItem.id)
                        .ToCollectionAsync();
                }
                catch (MobileServiceInvalidOperationException f)
                {
                    MessageBox.Show(f.Response.Content.ToString(),
                        string.Format("{0} (HTTP {1})", 
                        f.Response.Content,
                        f.Response.StatusCode), MessageBoxButton.OK);
                }
            }

            MainListBox.ItemsSource = items;

            progressBar1.IsEnabled = false;
            progressBar1.Visibility = Visibility.Collapsed;
            progressBar1.IsIndeterminate = false;
        }
    }
}