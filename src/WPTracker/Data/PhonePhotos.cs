using Newtonsoft.Json;
using System;

namespace WPTracker.Data
{
    public class PhonePhotos
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Address")]
        public Uri Address { get; set; }
    }
}
