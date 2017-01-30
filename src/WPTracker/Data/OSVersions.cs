using Newtonsoft.Json;

namespace WPTracker.Data
{
    public class OSVersions
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }

        [JsonProperty(PropertyName = "Version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "SortOrder")]
        public string SortOrder { get; set; }

        [JsonProperty(PropertyName = "Codename")]
        public string Codename { get; set; }

        [JsonProperty(PropertyName = "Publish")]
        public bool Publish { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public string Date { get; set; }

        [JsonProperty(PropertyName = "Changes")]
        public string Changes { get; set; }

        [JsonProperty(PropertyName = "Notes")]
        public string Notes { get; set; }

        [JsonProperty(PropertyName = "Branch")]
        public string Branch { get; set; }
    }
}
