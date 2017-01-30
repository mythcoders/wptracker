using System;

namespace WP7_Tracker.ViewModel.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class DevicesViewModel
    {
        private string deviceName;
        private string releaseDate;
        private string processorSpeed;
        private string deviceDimensions;
        private string deviceWeight;
        private string ram;
        private string rom;
        private string storage;
        private string batterySize;
        private string batteryTalk;
        private string batteryStandby;
        private string displayType;
        private string displayRes;
        private string displaySize;
        private string cameraRear;
        private string cameraFront;
        private string osMin;
        private string osMax;

        public string Name
        {
            get
            {
                return this.deviceName;
            }
            set
            {
                this.deviceName = value;
            }
        }

        public string Date
        {
            get
            {
                return this.releaseDate;
            }
            set
            {
                this.releaseDate = value;
            }
        }

        public string Processor
        {
            get
            {
                return this.processorSpeed;
            }
            set
            {
                this.processorSpeed = value;
            }
        }

        public string Dimensions
        {
            get
            {
                return this.deviceDimensions;
            }
            set
            {
                this.deviceDimensions = value;
            }
        }

        public string Weight
        {
            get
            {
                return this.deviceWeight;
            }
            set
            {
                this.deviceWeight = value;
            }
        }

        public string ROM
        {
            get
            {
                return this.rom;
            }
            set
            {
                this.rom = value;
            }
        }

        public string RAM
        {
            get
            {
                if (this.ram == "")
                {
                    this.ram = "N/A";
                }                               

                return this.ram;
            }
            set
            {
                this.ram = value;
            }
        }

        public string Storage
        {
            get
            {
                return this.storage;
            }
            set
            {
                this.storage = value;
            }
        }

        public string BatterySize
        {
            get
            {
                return this.batterySize;
            }
            set
            {
                this.batterySize = value;
            }
        }

        public string BatteryTalk
        {
            get
            {
                return this.batteryTalk;
            }
            set
            {
                this.batteryTalk = value;
            }
        }

        public string BatteryStandby
        {
            get
            {
                return this.batteryStandby;
            }
            set
            {
                this.batteryStandby = value;
            }
        }

        public string DisplayType
        {
            get
            {
                return this.displayType;
            }
            set
            {
                this.displayType = value;
            }
        }

        public string DisplayRes
        {
            get
            {
                return this.displayRes;
            }
            set
            {
                this.displayRes = value;
            }
        }

        public string DisplaySize
        {
            get
            {
                return this.displaySize;
            }
            set
            {
                this.displaySize = value;
            }
        }

        public string RFC
        {
            get
            {
                return this.cameraRear;
            }
            set
            {
                this.cameraRear = value;
            }
        }

        public string FFC
        {
            get
            {
                return this.cameraFront;
            }
            set
            {
                this.cameraFront = value;
            }
        }

        public string MinOS
        {
            get
            {
                return this.osMin;
            }
            set
            {
                this.osMin = value;
            }
        }

        public string MaxOS
        {
            get
            {
                return this.osMax;
            }
            set
            {
                this.osMax = value;
            }
        }
    }
}
