using Newtonsoft.Json;

namespace Module5_HW1.DTO
{
    public class LoginDTO
    {
        [JsonProperty("email")]
        public string Email { get; set; } = null!;

        [JsonProperty("password")]
        public string Password { get; set; } = null!;
    }
}
