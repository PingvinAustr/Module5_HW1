using Newtonsoft.Json;

namespace Module5_HW1.DTO
{
    public class ErrorDTO
    {
        [JsonProperty("error")]
        public string? Error { get; set; }
    }
}
