using System.Text.Json.Serialization;

namespace PayByMerchantTokenResponseModel;
public class Fee
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

public class FromFee
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

public class MerchantCommission
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

public class MerchantFee
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

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

    [JsonPropertyName("transactionReference")]
    public string TransactionReference { get; set; }
}

public class ToFee
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

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

