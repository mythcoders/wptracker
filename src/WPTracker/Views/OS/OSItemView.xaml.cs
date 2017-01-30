using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace WPTracker.Views.OS
{
    public partial class OSItemView : PhoneApplicationPage
    {        
        public OSItemView()
        {
            InitializeComponent();            
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   
            var listItem = App.SelectedVersion;

            LayoutRoot.DataContext = App.SelectedVersion;
        }
    }
}