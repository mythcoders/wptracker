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
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Primitives;

namespace WP7_Tracker.ViewModel
{
    public partial class Manufacturer : PhoneApplicationPage
    {
        public Manufacturer()
        {
            InitializeComponent();

            RadPhoneApplicationFrame frame = App.Current.RootVisual as RadPhoneApplicationFrame;
        }

        private void hubTile7_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Pro.xaml", UriKind.Relative));
        }

        private void hubTile8_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Trophy.xaml", UriKind.Relative));
        }

        private void hubTile9_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Mozart.xaml", UriKind.Relative));
        }

        private void hubTile10_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            RadMessageBox.Show(new AboutMessage[] 
            { 
                new AboutMessage() { Title = "HD7", Message = "Released on T-Mobile (US) at the launch of Windows Phone in the US." },
                new AboutMessage() { Title = "HD7 S", Message = "Revision to the HD7. Exculsive to AT&T with a few improvements." }
            },
            "Wait, there's more!",
            "Which device would you like to view?",
            closedHandler: (args) =>
            {
                if (args.ClickedButton == null)
                {
                    return;
                }

                AboutMessage option = (AboutMessage)args.ClickedButton.Content;
                if (option.Title == "HD7")
                {
                    NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/HD7.xaml", UriKind.Relative));
                }

                if (option.Title == "HD7 S")
                {
                    NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/HD7S.xaml", UriKind.Relative));
                }

                
            });

        }

        private void hubTile11_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Titan.xaml", UriKind.Relative));
        }

        private void hubTile12_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Radar.xaml", UriKind.Relative));
        }

        private void hubTile12_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Radar.xaml", UriKind.Relative));
        }

        private void hubTile1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/Focus.xaml", UriKind.Relative));
        }

        private void hubTile2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/FocusS.xaml", UriKind.Relative));
        }

        private void hubTile3_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/FocusFlash.xaml", UriKind.Relative));
        }

        private void hubTile4_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/Omina7.xaml", UriKind.Relative));
        }

        private void hubTile5_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/OminaW.xaml", UriKind.Relative));
        }

        private void hubTile13_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/LG/Optimus.xaml", UriKind.Relative));
        }

        private void hubTile14_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/LG/Quantum.xaml", UriKind.Relative));
        }

        private void hubTile16_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Nokia/Lumia710.xaml", UriKind.Relative));
        }

        private void hubTile17_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Nokia/Lumia800.xaml", UriKind.Relative));
        }

        private void hubTile19_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/ZTE/Tania.xaml", UriKind.Relative));
        }

        private void hubTile15_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Fujitsu/IS12T.xaml", UriKind.Relative));
        }

        private void hubTile18_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Acer/Allegro.xaml", UriKind.Relative));
        }

        private void hubTile6_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Dell/Venue.xaml", UriKind.Relative));
        }

        private void hubTile3_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }

        private void hubTile20_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {

        }
    }
}