using System.Text.Json.Serialization;

namespace RemoveBackground.Models
{
    /// <summary>
    /// Error format from the remove.bg service
    /// </summary>
    class ServiceError
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("detail")]
        public string Details { get; set; }
    }
}
