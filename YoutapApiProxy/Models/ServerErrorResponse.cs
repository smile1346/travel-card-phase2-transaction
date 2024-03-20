using System.Text.Json.Serialization;

namespace ServerErrorResponseModel;
public class Root
{
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; }

    [JsonPropertyName("path")]
    public string Path { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("error")]
    public string Error { get; set; }

    [JsonPropertyName("requestId")]
    public string RequestId { get; set; }
}

