using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace PaymentReversalRequestModel
{
    public class GeoLocation
    {
        [JsonPropertyName("latitude")]
        public decimal Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public decimal Longitude { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("reference")]
        [Required]
        [SwaggerSchema("Same as `fromTransactionId` or `transactionId` in the successful payment.")]
        public string Reference { get; set; }

        [JsonPropertyName("reverseFees")]
        public bool ReverseFees { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("geoLocation")]
        public GeoLocation GeoLocation { get; set; }
    }
}
