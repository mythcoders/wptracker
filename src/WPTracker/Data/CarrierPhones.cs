using Newtonsoft.Json;

namespace WPTracker.Data
{
    public class CarrierPhones
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "FullName")]
        public string FullName { get; set; }
    }
}
