using Newtonsoft.Json; 

namespace WPTracker.Data
{
    public class Regions
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Publish")]
        public bool Publish { get; set; }
    }
}
