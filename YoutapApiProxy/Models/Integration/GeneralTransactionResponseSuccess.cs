using System.Text.Json.Serialization;

namespace GeneralTransactionResponseSuccessModel;

public class Balance
{
    [JsonPropertyName("balanceType")]
    public string BalanceType { get; set; }

    [JsonPropertyName("balanceTypeDescription")]
    public string BalanceTypeDescription { get; set; }

    [JsonPropertyName("balanceUnit")]
    public string BalanceUnit { get; set; }

    [JsonPropertyName("balanceAmount")]
    public decimal BalanceAmount { get; set; }

    [JsonPropertyName("balanceDisplayAmount")]
    public string BalanceDisplayAmount { get; set; }
}

public class CustomerDetails
{
    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("mobileNumber")]
    public string MobileNumber { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("balance")]
    public Balance Balance { get; set; }
}

public class MerchantDetails
{
    [JsonPropertyName("accountId")]
    public int AccountId { get; set; }

    [JsonPropertyName("mobileNumber")]
    public string MobileNumber { get; set; }

    [JsonPropertyName("entityName")]
    public string EntityName { get; set; }

    [JsonPropertyName("balance")]
    public Balance Balance { get; set; }
}

public class Root
{
    [JsonPropertyName("merchantDetails")]
    public MerchantDetails MerchantDetails { get; set; }

    [JsonPropertyName("customerDetails")]
    public CustomerDetails CustomerDetails { get; set; }

    [JsonPropertyName("transactionDetails")]
    public TransactionDetails TransactionDetails { get; set; }
}

public class TransactionDetails
{
    [JsonPropertyName("transactionStatus")]
    public string TransactionStatus { get; set; }

    [JsonPropertyName("transactionDate")]
    public long TransactionDate { get; set; }

    [JsonPropertyName("paymentType")]
    public string PaymentType { get; set; }

    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("unit")]
    public string Unit { get; set; }

    [JsonPropertyName("fromFee")]
    public decimal FromFee { get; set; }

    [JsonPropertyName("toFee")]
    public decimal ToFee { get; set; }

    [JsonPropertyName("transactionId")]
    public string TransactionId { get; set; }

    [JsonPropertyName("transactionReference")]
    public string TransactionReference { get; set; }
}

