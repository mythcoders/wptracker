using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Cimbalino.Phone.Toolkit.Services;

namespace WPTracker.Views.Settings
{
    public partial class AppUpdate : PhoneApplicationPage
    {
        public AppUpdate()
        {
            InitializeComponent();
        }

        private async void CheckForUpdates()
        {
            var informationService = new MarketplaceInformationService();
            var applicationManifestService = new ApplicationManifestService();

            var result = await informationService.GetAppInformationAsync();
            var appInfo = applicationManifestService.GetApplicationManifest();
            var currentVersion = new Version(appInfo.App.Version);
            var updatedVersion = new Version(result.Entry.Version);


            if (updatedVersion > currentVersion && MessageBox.Show("Do you want to install the new version now?", "Update Available", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                new MarketplaceDetailTask().Show();
            }
            else
            {
                statusText.Text = "WPTracker is up to date";
            }
        }

        private void checkButton_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            statusText.Text = "Checking for updates ...";
            CheckForUpdates();
        }
    }
}