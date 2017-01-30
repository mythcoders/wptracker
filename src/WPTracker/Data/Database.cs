using Newtonsoft.Json;

namespace WPTracker.Data
{
    public class Database
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "Version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "Changes")]
        public string Changes { get; set; }

        [JsonProperty(PropertyName = "PublishDate")]
        public string PublishDate { get; set; }

        [JsonProperty(PropertyName = "Publish")]
        public bool Publish { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }
    }
}
