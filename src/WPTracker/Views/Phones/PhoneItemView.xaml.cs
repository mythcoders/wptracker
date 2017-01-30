using System;
using System.Linq;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Net.Http;
using WPTracker.Data;

namespace WPTracker.ViewModels.Phones
{
    public partial class PhoneItemView : PhoneApplicationPage
    {
        IEnumerable<Data.PhonePhotos> images = new List<Data.PhonePhotos>();
        
        public PhoneItemView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var selection = App.SelectedPhone;

            LayoutRoot.DataContext = selection;
            GetImages(selection.id);
        }

        private void sendInfo_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings/DeviceSpecs.xaml", UriKind.Relative));
        }

        private void reportInfo_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings/DataChanges.xaml", UriKind.Relative));
        }

        public async void GetImages(int id)
        {
            try
            {
                images = await App.MobileService.InvokeApiAsync<IEnumerable<PhonePhotos>>(
                    "devicesgetpictures",
                    HttpMethod.Get,
                    new Dictionary<string, string>()
                    {
                        { "phoneID", id.ToString() }
                    });

                var phonePhotoses = images as PhonePhotos[] ?? images.ToArray();

                if(phonePhotoses.Any())
                {
                    imageView.ItemsSource = phonePhotoses;
                    PhoneImageText.Text = "";
                }
                else
                {
                    PhoneImageText.Text = "No Image Available";
                }
            }
            catch (MobileServiceInvalidOperationException ex)
            {
                var message = ex.Message;
            }
        }
    }
}