using System.Text.Json.Serialization;

namespace RemoveBackground.Models
{
    /// <summary>
    /// Config file format for the plugin
    /// </summary>
    class Config
    {
        [JsonPropertyName("api-key")]
        public string ApiKey { get; set; }
    }
}
