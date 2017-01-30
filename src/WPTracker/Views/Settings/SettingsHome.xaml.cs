using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Telerik.Windows.Controls;

namespace WPTracker.Views.Settings
{
    public partial class SettingsHome : PhoneApplicationPage
    {
        public SettingsHome()
        {
            InitializeComponent();
        }

        private void notificationSetting_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings/ToastNotifications.xaml", UriKind.RelativeOrAbsolute));
        }

        private void offlineSetting_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings/Update.xaml", UriKind.RelativeOrAbsolute));
        }

        private void aboutSetting_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings/About.xaml", UriKind.RelativeOrAbsolute));
        }

        private void reviewSetting_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var review = new MarketplaceReviewTask();
            review.Show();
        }

        private void databaseChanges_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Database/DatabaseMainView.xaml", UriKind.Relative));
        }

        private async void feedback_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var userResponse = await RadMessageBox.ShowAsync("Send Feedback",
                    MessageBoxButtons.YesNo, "What type of feedback would you like to send?", null, false, false,
                    HorizontalAlignment.Stretch, VerticalAlignment.Stretch);

            if (userResponse.Result == DialogResult.OK)
            {
                // do something
            }
            else
            {
                // do something else
            }
            
            
            //RadMessageBox.ShowAsync("", new CustomMessageBox[]
            //{ 
            //    new CustomMessageBox() { Title = "General", Message = "Tell us what you like or don't like" },
            //    new CustomMessageBox() { Title = "Bug", Message = "Report any bugs that you find" },
            //    new CustomMessageBox() { Title = "Content", Message = "Suggest changes to data" }
            //},

            //"Send Feedback",
            //"What type of feedback?",
            //closedHandler: (args) =>
            //{
            //    if (args.ClickedButton == null)
            //    {
            //        return;
            //    }

            //    var option = (CustomMessageBox)args.ClickedButton.Content;
            //    if (option.Title == "General")
            //    {
            //        var emailComposeTask = new EmailComposeTask
            //        {
            //            Subject = "[WPTracker] Feedback",
            //            To = "support@adkinssd.com"
            //        };

            //        emailComposeTask.Show();
            //    }

            //    if (option.Title == "Bug")
            //    {
            //        var emailComposeTask = new EmailComposeTask
            //        {
            //            Subject = "[WPTracker] Bug Report",
            //            To = "support@adkinssd.com"
            //        };

            //        emailComposeTask.Show();
            //    }

            //    if (option.Title == "Content")
            //    {
            //        NavigationService.Navigate(new Uri("/Views/Settings/DataChanges.xaml", UriKind.Relative));
            //    }
            //}, verticalAlignment: VerticalAlignment.Stretch);
        }

        private void updateSetting_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/Settings/AppUpdate.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}