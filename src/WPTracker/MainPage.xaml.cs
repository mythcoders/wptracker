using System;
using Microsoft.Phone.Controls;
using System.Windows.Navigation;

namespace WPTracker
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();            

            (App.Current as App).rateReminder.Notify();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        private void osVersionsTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/OS/OSMainView.xaml", UriKind.RelativeOrAbsolute));            
        }

        private void allDevicesTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Phones/PhoneMainView.xaml", UriKind.RelativeOrAbsolute));
        }

        private void carrierTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Phones/CarrierRegion/PhoneCarrierView.xaml", UriKind.RelativeOrAbsolute));
        }

        private void settingsTile_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings/SettingsHome.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
