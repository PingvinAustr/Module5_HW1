using Newtonsoft.Json;

namespace Module5_HW1.DTO
{
    public class SupportDTO
    {
        [JsonProperty("url")]
        public string Url { get; set; } = null!;

        [JsonProperty("text")]
        public string Text { get; set; } = null!;
    }
}
