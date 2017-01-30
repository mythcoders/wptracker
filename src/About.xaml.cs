using System;
using System.Reflection;
using System.Linq;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Primitives;

namespace WP7_Tracker
{
    public partial class About : PhoneApplicationPage
    {
        public string TrialVersion = "Version: 2.0.30.1_Trial"; //About
        public string FullVersion = "Version: 2.0.30.1.alpha"; //About
        public string TrialVersion2 = "\n\n\n Version: 2.0 Trial"; //eMail
        public string FullVersion2 = "\n\n\n Version: 2.0"; //eMail      
 
        public About()
        {
            InitializeComponent();
            RadPhoneApplicationFrame frame = App.Current.RootVisual as RadPhoneApplicationFrame;
            
            if ((Application.Current as App).IsTrial)
            {
                this.purchaseButton.Visibility = System.Windows.Visibility.Visible;
                this.versionTextBlock.Text = TrialVersion;
            }
            else
            {
                this.purchaseButton.Visibility = System.Windows.Visibility.Collapsed;
                this.versionTextBlock.Text = FullVersion;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            RadMessageBox.Show(new AboutMessage[]
            { 
                new AboutMessage() { Title = "General", Message = "Tell us what you like or don't like" },
                new AboutMessage() { Title = "Bug", Message = "Report any bugs that you find" },
                new AboutMessage() { Title = "Content", Message = "Report any errors regarding content" }
            },

            "Feedback",
            "Which type of feedback would you like to send us?",
            closedHandler: (args) =>
            {
                if (args.ClickedButton == null)
                {
                    return;
                }

                AboutMessage option = (AboutMessage)args.ClickedButton.Content;
                if (option.Title == "General")
                {
                    if ((Application.Current as App).IsTrial)
                    {
                        EmailComposeTask emailComposeTask = new EmailComposeTask();
                        emailComposeTask.Subject = "[WP Tracker] Feedback";
                        emailComposeTask.To = "support@adkinssd.com";
                        emailComposeTask.Body = TrialVersion2;

                        emailComposeTask.Show();
                    }
                    else
                    {
                        EmailComposeTask emailComposeTask = new EmailComposeTask();
                        emailComposeTask.Subject = "[WP Tracker] Feedback";
                        emailComposeTask.To = "support@adkinssd.com";
                        emailComposeTask.Body = FullVersion2;

                        emailComposeTask.Show();
                    }
                }

                if (option.Title == "Bug")
                {
                    NavigationService.Navigate(new Uri("/BugTracker.xaml", UriKind.Relative));
                }

                if (option.Title == "Content")
                {
                    if ((Application.Current as App).IsTrial)
                    {
                        EmailComposeTask emailComposeTask = new EmailComposeTask();
                        emailComposeTask.Subject = "[WP Tracker] Content Error";
                        emailComposeTask.To = "support@adkinssd.com";
                        emailComposeTask.Body = TrialVersion2;

                        emailComposeTask.Show();
                    }
                    else
                    {
                        EmailComposeTask emailComposeTask = new EmailComposeTask();
                        emailComposeTask.Subject = "[WP Tracker] Content Error";
                        emailComposeTask.To = "support@adkinssd.com";
                        emailComposeTask.Body = FullVersion2;

                        emailComposeTask.Show();
                    }
                }
            }, verticalAlignment: System.Windows.VerticalAlignment.Stretch);            
        }

        private void hyperlinkButton2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://www.notebookheavy.com/", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void purchaseButton_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/FullVersion.xaml", UriKind.Relative));
        }

        private void rateButton_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();
        }

        private void logoImage_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();
            marketplaceSearchTask.SearchTerms = "Adkins Software Development";
            marketplaceSearchTask.ContentType = MarketplaceContentType.Applications;
            marketplaceSearchTask.Show();
        }
    }
}