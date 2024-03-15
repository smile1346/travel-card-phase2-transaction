using System.Text.Json.Serialization;

namespace GetTransactionLimitsResponseModel;

// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);
public class Root
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("shortName")]
    public string ShortName { get; set; }

    [JsonPropertyName("longName")]
    public string LongName { get; set; }

    [JsonPropertyName("crtcLower")]
    public int CrtcLower { get; set; }

    [JsonPropertyName("crtcUpper")]
    public object CrtcUpper { get; set; }

    [JsonPropertyName("bevtid1")]
    public int Bevtid1 { get; set; }

    [JsonPropertyName("sumDay")]
    public int SumDay { get; set; }

    [JsonPropertyName("sumMonth")]
    public int SumMonth { get; set; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }

    [JsonPropertyName("display")]
    public bool Display { get; set; }
}

