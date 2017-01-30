using Newtonsoft.Json;

namespace WPTracker.Data
{
    public class Carriers
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "CountryID")]
        public int CountryID { get; set; }

        [JsonProperty(PropertyName = "Publish")]
        public bool Publish { get; set; }
    }
}
