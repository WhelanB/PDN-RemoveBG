using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RemoveBackground.Models
{
    /// <summary>
    /// Error response from remove.bg service
    /// </summary>
    class ServiceErrorResponse
    {
        [JsonPropertyName("errors")]
        public List<ServiceError> Errors { get; set; }
    }
}
