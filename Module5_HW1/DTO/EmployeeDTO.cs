using Newtonsoft.Json;

namespace Module5_HW1.DTO
{
    public class EmployeeDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("job")]
        public string Job { get; set; } = null!;

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; } = null!;

        [JsonProperty("updatedAt")]
        public string? UpdatedAt { get; set; }
    }
}
