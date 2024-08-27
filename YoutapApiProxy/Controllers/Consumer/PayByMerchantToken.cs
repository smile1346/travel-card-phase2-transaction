using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using System.Text.Json.Serialization;

namespace Controllers
{

    readonly partial struct Consumer
    {
        // OK
        [ProducesResponseType(typeof(PayByMerchantTokenResponseModel.Root), (int)HttpStatusCode.OK)]
        // [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(WebhookExample))]

        // Request Body
        [Consumes(typeof(PayByMerchantTokenRequestModel.Root), MediaTypeNames.Application.Json)]

        [SwaggerOperation(Summary = "Purchase by Scanning Merchant Dynamic QR Code (C-Scan-B)", Description = @"
Make a payment by scanning a QR code presented by a merchant. That QR code will contain the information required to fill in the request body.")]
        public static IResult PayByMerchantToken(
    [SwaggerParameter("The `Account Number` of the customer, as shown in CMS portal.")] string accountId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature)
        {
            var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
            return Results.Text(result, MediaTypeNames.Application.Json);
        }

    }
}

namespace PayByMerchantTokenRequestModel
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Root
    {
        [JsonPropertyName("transactionAmount")]
        public TransactionAmount TransactionAmount { get; set; }

        [JsonPropertyName("balanceType")]
        public string BalanceType { get; set; }

        [JsonPropertyName("customerPin")]
        public string CustomerPin { get; set; }

        [JsonPropertyName("merchantId")]
        public string MerchantId { get; set; }

        [JsonPropertyName("billReference")]
        public string BillReference { get; set; }
    }

    public class TransactionAmount
    {
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }



}

namespace PayByMerchantTokenResponseModel
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Fee
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }

    public class FromFee
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }

    public class MerchantCommission
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }

    public class MerchantFee
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }

    public class Metric
    {
        [JsonPropertyName("unitLongName")]
        public string UnitLongName { get; set; }

        [JsonPropertyName("unitShortName")]
        public string UnitShortName { get; set; }

        [JsonPropertyName("displayString")]
        public string DisplayString { get; set; }

        [JsonPropertyName("displayDivisor")]
        public int DisplayDivisor { get; set; }

        [JsonPropertyName("displayUnitDelimiter")]
        public string DisplayUnitDelimiter { get; set; }

        [JsonPropertyName("displayUnitMinorDelimiter")]
        public string DisplayUnitMinorDelimiter { get; set; }

        [JsonPropertyName("displayFormatter")]
        public string DisplayFormatter { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("transactionAmount")]
        public TransactionAmount TransactionAmount { get; set; }

        [JsonPropertyName("transactionAmountDisplay")]
        public string TransactionAmountDisplay { get; set; }

        [JsonPropertyName("fee")]
        public Fee Fee { get; set; }

        [JsonPropertyName("merchantFee")]
        public MerchantFee MerchantFee { get; set; }

        [JsonPropertyName("merchantFeeDisplay")]
        public string MerchantFeeDisplay { get; set; }

        [JsonPropertyName("toFee")]
        public ToFee ToFee { get; set; }

        [JsonPropertyName("toFeeDisplay")]
        public string ToFeeDisplay { get; set; }

        [JsonPropertyName("fromFee")]
        public FromFee FromFee { get; set; }

        [JsonPropertyName("fromFeeDisplay")]
        public string FromFeeDisplay { get; set; }

        [JsonPropertyName("coupon")]
        public object Coupon { get; set; }

        [JsonPropertyName("merchantCommission")]
        public MerchantCommission MerchantCommission { get; set; }

        [JsonPropertyName("merchantCommissionDisplay")]
        public string MerchantCommissionDisplay { get; set; }

        [JsonPropertyName("paymentTrailId")]
        public string PaymentTrailId { get; set; }

        [JsonPropertyName("barcodeTitle1")]
        public string BarcodeTitle1 { get; set; }

        [JsonPropertyName("barcodeDetail1")]
        public string BarcodeDetail1 { get; set; }

        [JsonPropertyName("barcodeTitle2")]
        public string BarcodeTitle2 { get; set; }

        [JsonPropertyName("barcodeDetail2")]
        public string BarcodeDetail2 { get; set; }

        [JsonPropertyName("metric")]
        public Metric Metric { get; set; }

        [JsonPropertyName("transactionUTCDateTime")]
        public DateTime TransactionUTCDateTime { get; set; }
    }

    public class ToFee
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }

    public class TransactionAmount
    {
        [JsonPropertyName("amount")]
        public double Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }


}