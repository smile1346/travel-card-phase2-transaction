
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GetQRStringResponseModel;

public class Root
{
    [JsonPropertyName("cpmQrCode")]
    public string CpmQrCode { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("expires_at")]
    public DateTime ExpiresAt { get; set; }
}

