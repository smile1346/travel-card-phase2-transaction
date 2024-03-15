using System.Text.Json.Serialization;

namespace GetLinkedExternalAccountsResponseModel;

public class Identifier
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("customerId")]
    public int CustomerId { get; set; }

    [JsonPropertyName("identifierId")]
    public int IdentifierId { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }

    [JsonPropertyName("identifierCode")]
    public string IdentifierCode { get; set; }

    [JsonPropertyName("identifierDesc")]
    public string IdentifierDesc { get; set; }

    [JsonPropertyName("identifierType")]
    public string IdentifierType { get; set; }

    [JsonPropertyName("identifierGroupId")]
    public int IdentifierGroupId { get; set; }

    [JsonPropertyName("verified")]
    public bool Verified { get; set; }

    [JsonPropertyName("photoIdentities")]
    public object PhotoIdentities { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("expiryDate")]
    public string ExpiryDate { get; set; }
}

public class Root
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("customerId")]
    public string CustomerId { get; set; }

    [JsonPropertyName("externalAccount")]
    public string ExternalAccount { get; set; }

    [JsonPropertyName("externalAccountName")]
    public string ExternalAccountName { get; set; }

    [JsonPropertyName("provider")]
    public string Provider { get; set; }

    [JsonPropertyName("providerDescription")]
    public string ProviderDescription { get; set; }

    [JsonPropertyName("acctid")]
    public string Acctid { get; set; }

    [JsonPropertyName("msisdn")]
    public string Msisdn { get; set; }

    [JsonPropertyName("identifier")]
    public Identifier Identifier { get; set; }
}

