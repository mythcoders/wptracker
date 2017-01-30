using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace WP7_Tracker.ViewModel.Data
{
    public class DeviceViewModel
    {

        public string Name
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }

        public string NavName
        {
            get;
            set;
        }

        public string Processor
        {
            get;
            set;
        }

        public string Dimensions
        {
            get;
            set;
        }

        public string Weight
        {
            get;
            set;
        }

        public string CPU
        {
            get;
            set;
        }

        public string RAM
        {
            get;
            set;
        }

        public string ROM
        {
            get;
            set;
        }

        public string Storage
        {
            get;
            set;
        }

        public string BatterySize
        {
            get;
            set;
        }

        public string BatteryTalk
        {
            get;
            set;
        }

        public string BatteryStandby
        {
            get;
            set;
        }

        public string DisplayType
        {
            get;
            set;
        }

        public string DisplayRes
        {
            get;
            set;
        }

        public string DisplaySize
        {
            get;
            set;
        }

        public string FrontCamera
        {
            get;
            set;
        }

        public string RearCamera
        {
            get;
            set;
        }

        public string MinOS
        {
            get;
            set;
        }

        public string MaxOS
        {
            get;
            set;
        }

        public static List<DeviceViewModel> GetAllDevices()
        {
            List<DeviceViewModel> allDevices = new List<DeviceViewModel>();
            using (XmlReader xmlReader = XmlReader.Create("ViewModel/devices.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<DeviceViewModel>));
                List<DeviceViewModel> devices = deserializer.Deserialize(xmlReader) as List<DeviceViewModel>;
            }

            return allDevices;
        }

    }
}
