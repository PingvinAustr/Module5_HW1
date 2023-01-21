using Newtonsoft.Json;

namespace Module5_HW1.DTO.Responses;
public class RegisterResponse
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("token")]
    public string? Token { get; set; }
}
