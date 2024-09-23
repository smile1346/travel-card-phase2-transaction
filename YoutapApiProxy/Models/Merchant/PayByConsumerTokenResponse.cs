using System.Text.Json.Serialization;

namespace PayByConsumerTokenResponseModel;
public class FromFee
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

public class Root
{
    [JsonPropertyName("transactionRef")]
    public string TransactionRef { get; set; }

    [JsonPropertyName("balanceTypeId")]
    public int BalanceTypeId { get; set; }

    [JsonPropertyName("txnDate")]
    public long TxnDate { get; set; }

    [JsonPropertyName("fromFee")]
    public FromFee FromFee { get; set; }

    [JsonPropertyName("toFee")]
    public ToFee ToFee { get; set; }
}

public class ToFee
{
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }
}

