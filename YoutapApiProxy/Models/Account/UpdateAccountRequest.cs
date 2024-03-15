using System.Text.Json.Serialization;

namespace UpdateAccountRequestModel;

public class Root
{
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("color")]
    public string Color { get; set; }
}

