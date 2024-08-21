
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace GetQRStringResponseModel;

public class Root
{
    [DefaultValue("hQVDUFYwMWFJTwhgiGQA/wAABFAHTU1QQVkwNFoJYIhkAEUBAAAAX1ATdGVsOis2NC0yMi01MzMtMjU2OGMT33QQNjA4ODY0MDA4NDQ4NzAwOA==")]
    [JsonPropertyName("cpmQrCode")]
    public string CpmQrCode { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("expires_at")]
    public DateTime ExpiresAt { get; set; }
}

