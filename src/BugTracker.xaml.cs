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
using Telerik.Windows.Controls.Input;

namespace WP7_Tracker
{
    public partial class BugTracker : PhoneApplicationPage
    {
        public BugTracker()
        {
            InitializeComponent();

            this.componentPicker.ItemsSource = component;
            this.componentPicker.SelectedItem = "General";

            this.versionPicker.ItemsSource = version;
            this.versionPicker.SelectedItem = "1.1";

            this.priorityPicker.ItemsSource = priority;
            this.priorityPicker.SelectedItem = "Normal";

            this.severityPicker.ItemsSource = severity;
            this.severityPicker.SelectedItem = "normal";
        }

        List<string> component = new List<string>() { "General", "All Devices Hub", "Manufacturer Hub", "OS Versions Hub", "Trial", "Other" };
        List<string> severity = new List<string>() { "blocker", "critical", "major", "normal", "minor", "trivial", "enhancement" };
        List<string> priority = new List<string>() { "Highest", "High", "Normal", "Low", "Lowest", "---" };
        List<string> version = new List<string>() { "1.0", "1.1", "1.2", "1.3", "2.0"};

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Subject = summaryTextBox.Text;
            emailComposeTask.To = "bugzilla@adkinssd.com";
            emailComposeTask.Body = "@product WP7 Tracker" + "\n@component " + componentPicker.SelectedItem + "\n@version " + versionPicker.SelectedItem + "\n@priority " + priorityPicker.SelectedItem + "\n@severity " + severityPicker.SelectedItem;

            emailComposeTask.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask webBrowserTask = new WebBrowserTask();
            webBrowserTask.Uri = new Uri("http://bugzilla.adkinssd.com/createaccount.cgi", UriKind.Absolute);
            webBrowserTask.Show();
        }
    }
}