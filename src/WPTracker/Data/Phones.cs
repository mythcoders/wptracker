using Newtonsoft.Json;

namespace WPTracker.Data
{
    public class Phones
    {
        #region Summary
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "Make")]
        public string Make { get; set; }

        [JsonProperty(PropertyName = "Model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "RAM")]
        public string RAM { get; set; }

        [JsonProperty(PropertyName = "Storage")]
        public string Storage { get; set; }

        [JsonProperty(PropertyName = "MinOS")]
        public string MinOS { get; set; }

        [JsonProperty(PropertyName = "MaxOS")]
        public string MaxOS { get; set; }

        [JsonProperty(PropertyName = "Publish")]
        public bool Publish { get; set; }

        [JsonProperty(PropertyName = "Notes")]
        public string Notes { get; set; }

        [JsonProperty(PropertyName = "FullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "CarrierID")]
        public int CarrierID { get; set; }

        [JsonProperty(PropertyName = "DisplayType")]
        public string DisplayType { get; set; }

        [JsonProperty(PropertyName = "Resolution")]
        public string Resolution { get; set; }

        [JsonProperty(PropertyName = "DisplaySize")]
        public string DisplaySize { get; set; }

        [JsonProperty(PropertyName = "DeviceGeneration")]
        public string DeviceGeneration { get; set; }

        #endregion

        #region Design
        [JsonProperty(PropertyName = "Dimensions")]
        public string Dimensions { get; set; }

        [JsonProperty(PropertyName = "Weight")]
        public string Weight { get; set; }

        [JsonProperty(PropertyName = "Sensors")]
        public string Sensors { get; set; }

        #endregion

        #region Connectivity

        [JsonProperty(PropertyName = "SIMCardType")]
        public string SIMCardType { get; set; }

        [JsonProperty(PropertyName = "ChargingConnectors")]
        public string ChargingConnectors { get; set; }

        [JsonProperty(PropertyName = "AVConnectors")]
        public string AVConnectors { get; set; }

        [JsonProperty(PropertyName = "SystemConnectors")]
        public string SystemConnectors { get; set; }

        [JsonProperty(PropertyName = "USBVersion")]
        public string USBVersion { get; set; }

        [JsonProperty(PropertyName = "BluetoothVersion")]
        public string BluetoothVersion { get; set; }

        [JsonProperty(PropertyName = "BluetoothProfiles")]
        public string BluetoothProfiles { get; set; }

        [JsonProperty(PropertyName = "WiFiVersion")]
        public string WiFiVersion { get; set; }

        [JsonProperty(PropertyName = "WiFiSecurityModes")]
        public string WiFiSecurityModes { get; set; }

        [JsonProperty(PropertyName = "WirelessConnectivity")]
        public string WirelessConnectivity { get; set; }

        [JsonProperty(PropertyName = "NFC")]
        public bool NFC { get; set; }

        #endregion

        #region Data

        [JsonProperty(PropertyName = "GSMTypes")]
        public string GSMTypes { get; set; }

        [JsonProperty(PropertyName = "GSMUpload")]
        public string GSMUpload { get; set; }

        [JsonProperty(PropertyName = "GSMDownload")]
        public string GSMDownload { get; set; }

        [JsonProperty(PropertyName = "LTETypes")]
        public string LTETypes { get; set; }

        [JsonProperty(PropertyName = "LTEUpload")]
        public string LTEUpload { get; set; }

        [JsonProperty(PropertyName = "LTEDownload")]
        public string LTEDownload { get; set; }

        [JsonProperty(PropertyName = "WCDMATypes")]
        public string WCDMATypes { get; set; }

        [JsonProperty(PropertyName = "WCDMAUpload")]
        public string WCDMAUpload { get; set; }

        [JsonProperty(PropertyName = "WCDMADownload")]
        public string WCDMADownload { get; set; }

        #endregion

        #region Power Management

        [JsonProperty(PropertyName = "BatterySize")]
        public string BatterySize { get; set; }

        [JsonProperty(PropertyName = "TalkTime")]
        public string TalkTime { get; set; }

        [JsonProperty(PropertyName = "StandbyTime")]
        public string StandbyTime { get; set; }

        [JsonProperty(PropertyName = "BatteryVoltage")]
        public string BatteryVoltage { get; set; }

        [JsonProperty(PropertyName = "RemoveableBattery")]
        public bool RemoveableBattery { get; set; }

        [JsonProperty(PropertyName = "MaxMusicPlayback")]
        public string MaxMusicPlayback { get; set; }

        [JsonProperty(PropertyName = "MaxVideoPlayback")]
        public string MaxVideoPlayback { get; set; }

        [JsonProperty(PropertyName = "MaxWiFiTime")]
        public string MaxWiFiTime { get; set; }

        #endregion

        #region Processor

        [JsonProperty(PropertyName = "ProcessorSpeed")]
        public string ProcessorSpeed { get; set; }

        [JsonProperty(PropertyName = "ProcessorName")]
        public string ProcessorName { get; set; }

        [JsonProperty(PropertyName = "ProcessorType")]
        public string ProcessorType { get; set; }

        #endregion

        #region Camera
        [JsonProperty(PropertyName = "RearCamera")]
        public string RearCamera { get; set; }

        [JsonProperty(PropertyName = "FrontCamera")]
        public string FrontCamera { get; set; }

        [JsonProperty(PropertyName = "RearAperture")]
        public string RearAperture { get; set; }

        [JsonProperty(PropertyName = "RearFocalLength")]
        public string RearFocalLength { get; set; }

        [JsonProperty(PropertyName = "RearMinFocusRange")]
        public string RearMinFocusRange { get; set; }

        [JsonProperty(PropertyName = "FlashType")]
        public string FlashType { get; set; }

        [JsonProperty(PropertyName = "FlashOperatingRange")]
        public string FlashOperatingRange { get; set; }

        [JsonProperty(PropertyName = "FrontResolution")]
        public string FrontResolution { get; set; }

        [JsonProperty(PropertyName = "FrontAperture")]
        public string FrontAperture { get; set; }
        #endregion               
    }
}
