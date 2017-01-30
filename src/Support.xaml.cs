using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace WP7_Tracker
{
    public partial class Support : PhoneApplicationPage
    {
        public Support()
        {
            InitializeComponent();
        }

        private void hyperlinkButton1_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://adkinssdportal.ontimenow.com", UriKind.Absolute);
            webBrowserTask.Show();
        }

        private void hyperlinkButton2_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();

            emailComposeTask.Subject = "WP7 Tracker Feedback";
            emailComposeTask.To = "adkinssd@live.com";

            emailComposeTask.Show();
        }
    }
}