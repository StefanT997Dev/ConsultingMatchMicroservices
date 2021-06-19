using Newtonsoft.Json;

namespace Application.DTOs
{
    public class ConsultantSearchDto
    {
        [JsonProperty("title")]
        public string Id { get; set; }
        [JsonProperty("description")]
        public string DisplayName { get; set; }
    }
}