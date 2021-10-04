using Newtonsoft.Json;

namespace RemoveBackground.Models
{
    /// <summary>
    /// Config file format for the plugin
    /// </summary>
    class Config
    {
        [JsonProperty(PropertyName = "api-key")]
        public string ApiKey { get; set; }
    }
}
