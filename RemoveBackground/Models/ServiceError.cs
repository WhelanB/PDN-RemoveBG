using Newtonsoft.Json;

namespace RemoveBackground.Models
{
    /// <summary>
    /// Error format from the remove.bg service
    /// </summary>
    class ServiceError
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "detail")]
        public string Details { get; set; }
    }
}
