using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;
using WPTracker.Data;

namespace WPTracker.ViewModels.Phones
{
    public partial class PhoneCarrierView : PhoneApplicationPage
    {
        private readonly IMobileServiceTable<Regions> _regionsTable = App.MobileService.GetTable<Regions>();
        private readonly IMobileServiceTable<Carriers> _carrierTable = App.MobileService.GetTable<Carriers>();

        IEnumerable<Regions> _regionsList = new List<Regions>();
        IEnumerable<Carriers> _carrierList = new List<Carriers>();
        IEnumerable<CarrierPhones> _phoneList = new List<CarrierPhones>();
        
        public PhoneCarrierView()
        {
            InitializeComponent();

            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.IsEnabled = true;

            GetRegions();
        }

        private async void GetRegions()
        {
            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.IsEnabled = true;

            try
            {
                _regionsList = await _regionsTable
                    .Where(regionItem => regionItem.Publish == true)
                    .OrderBy(regionItem => regionItem.Name)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException f)
            {
                MessageBox.Show(f.Response.Content.ToString(),
                        string.Format("{0} (HTTP {1})",
                        f.Response.Content,
                        f.Response.StatusCode), MessageBoxButton.OK);
            }

            regionPicker.ItemsSource = _regionsList;
        }
        
        private async void GetCarriers(int regionID)
        {
            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.IsEnabled = true;

            try
            {
                _carrierList = await _carrierTable
                    .Where(carrierItem => carrierItem.CountryID == regionID)
                    .OrderBy(carrierItem => carrierItem.Name)
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException f)
            {
                MessageBox.Show(f.Response.Content.ToString(),
                        string.Format("{0} (HTTP {1})",
                        f.Response.Content,
                        f.Response.StatusCode), MessageBoxButton.OK);
            }

            carrierPicker.ItemsSource = _carrierList;
        }

        private async void GetDevices(string carrierName)
        {
            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.IsEnabled = true;

            try
            {
                _phoneList = await App.MobileService.InvokeApiAsync<IEnumerable<CarrierPhones>>(
                    "carriersgetdevices",
                    HttpMethod.Get,
                    new Dictionary<string, string>()
                    {
                        { "carrierName", carrierName }
                    }
                    );

                this.MainListBox.ItemsSource = _phoneList;                
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                string message;
                
                message = ex.Message;
            }

            ProgressBar.Visibility = Visibility.Collapsed;
            ProgressBar.IsEnabled = false;
        }

        private void carrierPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var carrier = carrierPicker.SelectedItem as Carriers;
            string carrierName = carrier.Name;

            GetDevices(carrierName);
        }

        private void regionPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.IsEnabled = true;

            var region = regionPicker.SelectedItem as Regions;
            var regionId = region.ID;

            GetCarriers(regionId);
        }

        private async void MainListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProgressBar.Visibility = Visibility.Visible;
            ProgressBar.IsEnabled = true;

            var phoneTable = App.MobileService.GetTable<Data.Phones>();

            var selectedItem = MainListBox.SelectedItem as CarrierPhones;

            //Query database
            try
            {
                var phone = await phoneTable
                    .Where(p => p.FullName == selectedItem.FullName).ToCollectionAsync();

                if(phone.Count > 0)
                {
                    App.SelectedPhone = phone.FirstOrDefault();

                    NavigationService.Navigate(new Uri("/Views/Phones/PhoneItemView.xaml", UriKind.Relative));
                }
            }
            catch (MobileServiceInvalidOperationException f)
            {
                MessageBox.Show(f.Response.Content.ToString(),
                        string.Format("{0} (HTTP {1})",
                        f.Response.Content,
                        f.Response.StatusCode), MessageBoxButton.OK);
            }

            ProgressBar.Visibility = Visibility.Collapsed;
            ProgressBar.IsEnabled = false;
        }
    }
}