using System.Text.Json.Serialization;

namespace KYCRegistrationResponseModel;

public class Root{
    [JsonPropertyName("id")]
    public string Id;

    [JsonPropertyName("customerId")]
    public string CustomerId;

    [JsonPropertyName("status")]
    public string Status;

    [JsonPropertyName("entityName")]
    public string EntityName;
}