using System.Windows;
using Microsoft.Phone.Tasks;
using Microsoft.Phone.Net.NetworkInformation;
using WPTracker.Helpers;

namespace WPTracker
{
    public partial class DeviceSpecs
    {
        public DeviceSpecs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var device = PhoneNameResolver.Resolve(
               Microsoft.Phone.Info.DeviceStatus.DeviceManufacturer,
               Microsoft.Phone.Info.DeviceStatus.DeviceName);

            string devicePublicName = device.FullCanonicalName;
            string deviceManufacturer = device.ReportedManufacturer;
            string deviceName = device.ReportedModel;
            
            var emailComposeTask = new EmailComposeTask
            {
                Subject = "[WPTracker] DeviceSpecs - " + devicePublicName,
                To = "support@adkinssd.com",
                Body = "Hardware Version: " +
                       Microsoft.Phone.Info.DeviceStatus.DeviceHardwareVersion + "\nFirmware Version: " +
                       Microsoft.Phone.Info.DeviceStatus.DeviceFirmwareVersion + "\nDevice Memory: " +
                       deviceManufacturer + " " + deviceName +
                       Microsoft.Phone.Info.DeviceStatus.DeviceTotalMemory + "\nCarrier: " +
                       DeviceNetworkInformation.CellularMobileOperator + "\nCountry of Device Purchase: "
            };

            emailComposeTask.Show();
        }
    }
}