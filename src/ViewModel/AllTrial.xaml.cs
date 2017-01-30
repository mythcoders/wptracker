using System;
using Microsoft.Phone.Controls;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Primitives;
using Telerik.Windows.Data;
using WP7_Tracker.ViewModel.Data;

namespace WP7_Tracker.ViewModel
{
    public partial class AllTrial : PhoneApplicationPage
    {
        public AllTrial()
        {
            InitializeComponent();
            RadPhoneApplicationFrame frame = App.Current.RootVisual as RadPhoneApplicationFrame;

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Acer/Allegro.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Dell/Venue.xaml", UriKind.Relative));
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Pro.xaml", UriKind.Relative));
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Trophy.xaml", UriKind.Relative));
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Mozart.xaml", UriKind.Relative));
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/HD7.xaml", UriKind.Relative));
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/HD7S.xaml", UriKind.Relative));
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Titan.xaml", UriKind.Relative));
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/Radar.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Fujitsu/IS12T.xaml", UriKind.Relative));
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/LG/Optimus.xaml", UriKind.Relative));
        }

        private void button12_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/LG/Quantum.xaml", UriKind.Relative));
        }

        private void button13_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Nokia/Lumia710.xaml", UriKind.Relative));
        }

        private void button14_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Nokia/Lumia800.xaml", UriKind.Relative));
        }

        private void button15_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/Focus.xaml", UriKind.Relative));
        }

        private void button16_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/FocusS.xaml", UriKind.Relative));
        }

        private void button17_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/FocusFlash.xaml", UriKind.Relative));
        }

        private void button18_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/Omina7.xaml", UriKind.Relative));
        }

        private void button19_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Samsung/OminaW.xaml", UriKind.Relative));
        }

        private void button20_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/ZTE/Tania.xaml", UriKind.Relative));
        }

        private void button21_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/Nokia/Lumia900.xaml", UriKind.Relative));
        }

        private void button22_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewModel/Devices/HTC/TitanII.xaml", UriKind.Relative));
        }
    }
}