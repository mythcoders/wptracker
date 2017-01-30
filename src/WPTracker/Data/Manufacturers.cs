using Newtonsoft.Json;

namespace WPTracker.Data
{
    public class Manufacturers
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "Make")]
        public string Make { get; set; }

        [JsonProperty(PropertyName = "Publish")]
        public bool Publish { get; set; }
    }
}
