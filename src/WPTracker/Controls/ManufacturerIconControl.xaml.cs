using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPTracker.Controls
{
    public partial class ManufacturerIconControl : UserControl
    {
        public ManufacturerIconControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }

        public static readonly DependencyProperty ManufacturerProperty = DependencyProperty.Register(
                                          "ManufacturerIcon",
                                          typeof(string),
                                          typeof(ManufacturerIconControl),
                                          new PropertyMetadata(null, OnManufacturerPropertyChanged));

        private static void OnManufacturerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ManufacturerIconControl).UpdateManufacturer((string)e.NewValue);
        }

        private void UpdateManufacturer(string manufacturer)
        {
            switch (manufacturer)
            {
                case "Nokia":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/nokia.png", UriKind.Relative));
                    break;
                case "HTC":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/htc.png", UriKind.Relative));
                    break;
                case "Samsung":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/samsung.png", UriKind.Relative));
                    break;
                case "Huawei":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/huawei.png", UriKind.Relative));
                    break;
                case "Dell":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/dell.png", UriKind.Relative));
                    break;
                case "LG":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/lg.png", UriKind.Relative));
                    break;
                case "ZTE":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/zte.jpg", UriKind.Relative));
                    break;
                case "Fujitsu":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/fujitsu.png", UriKind.Relative));
                    break;
                case "Acer":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/acer.png", UriKind.Relative));
                    break;
                case "Alcatel":
                    ManufacturerIcon.Source = new BitmapImage(new Uri("/Images/Logos/alcatel.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        public string Manufacturer
        {
            get
            {
                return (string)GetValue(ManufacturerProperty);
            }
            set
            {
                SetValue(ManufacturerProperty, value);
            }
        }
    }
}
