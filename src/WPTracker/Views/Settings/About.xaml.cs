using Microsoft.Phone.Controls;

namespace WPTracker.Settings
{
    public partial class About : PhoneApplicationPage
    {
        private const string version = "Version 3.0.75.13";
        private const string milestone = "rc";
        private const string codename = "Aphrodite";

        public About()
        {
            InitializeComponent();

            VersionNumberTextBox.Text = version + "." + milestone + " - " + codename;
        }
    }
}