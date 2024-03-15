using System.Text.Json.Serialization;

namespace ErrorResponseModel;

public class Root
{
    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    [JsonPropertyName("errorCode")]
    public string ErrorCode { get; set; }

    [JsonPropertyName("errorDescription")]
    public string ErrorDescription { get; set; }

    [JsonPropertyName("errorKey")]
    public string ErrorKey { get; set; }

    [JsonPropertyName("instance")]
    public string Instance { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}