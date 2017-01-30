using System.Windows;
using Microsoft.Phone.Controls;

namespace WPTracker.Settings
{
    public partial class ToastNotifications : PhoneApplicationPage
    {
        public ToastNotifications()
        {
            InitializeComponent();
            var appSettings = (AppSettings)Resources["appSettings"];
        }

        private void toastNotification_Checked(object sender, RoutedEventArgs e)
        {
            var value = true;

            var toaster = new Helpers.ToastNotificationHandler();
            toaster.Toaster(value);
        }

        private void toastNotification_Unchecked(object sender, RoutedEventArgs e)
        {
            var value = false;

            var toaster = new Helpers.ToastNotificationHandler();
            toaster.Toaster(value);
        }
    }
}