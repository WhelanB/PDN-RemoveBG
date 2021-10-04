using System.Collections.Generic;
using Newtonsoft.Json;

namespace RemoveBackground.Models
{
    /// <summary>
    /// Error response from remove.bg service
    /// </summary>
    class ServiceErrorResponse
    {
        [JsonProperty(PropertyName = "errors")]
        public List<ServiceError> Errors { get; set; }
    }
}
