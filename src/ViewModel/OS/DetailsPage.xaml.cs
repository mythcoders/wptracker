using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Primitives;

namespace WP7_Tracker.ViewModel.OS
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        // Constructor
        public DetailsPage()
        {
            InitializeComponent();
            RadPhoneApplicationFrame frame = App.Current.RootVisual as RadPhoneApplicationFrame;

            if ((Application.Current as App).IsTrial)
            {
                textBlock1.Text = "Change Log available in full version only!";
                textBlock2.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        
        // When page is navigated to set data context to selected item in list
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                int index = int.Parse(selectedIndex);
                DataContext = App.ViewModel.Items[index];
            }
        }
    }
}