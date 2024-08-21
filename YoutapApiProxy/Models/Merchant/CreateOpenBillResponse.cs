using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CreateOpenBillResponseModel;
public class Root
{
    [JsonPropertyName("openBillId")]
    public long OpenBillId { get; set; }

    [JsonPropertyName("billReference")]
    public string BillReference { get; set; }

    [JsonPropertyName("merchantId")]
    public string MerchantId { get; set; }

    [JsonPropertyName("terminalId")]
    public string TerminalId { get; set; }

    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; }

    [JsonPropertyName("customerMsisdn")]
    public string CustomerMsisdn { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("transactionAmount")]
    public decimal TransactionAmount { get; set; }

    [JsonPropertyName("mpmEmvQrCodeString")]
    public string MpmEmvQrCodeString { get; set; }

    [JsonPropertyName("creationTimestamp")]
    public DateTime CreationTimestamp { get; set; }

    [JsonPropertyName("expiryTimestamp")]
    public DateTime ExpiryTimestamp { get; set; }

    [JsonPropertyName("payments")]
    public List<Payment> Payments { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("salesResponse")]
    public SalesResponse SalesResponse { get; set; }

    [JsonPropertyName("billableEvent")]
    public long BillableEvent { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("extBillReference")]
    public string ExtBillReference { get; set; }

    [JsonPropertyName("balanceTypeId")]
    public long BalanceTypeId { get; set; }
}

public class Payment
{
    [JsonPropertyName("billReference")]
    public string BillReference { get; set; }

    [JsonPropertyName("transactionRef")]
    public string TransactionRef { get; set; }

    [JsonPropertyName("externalTransactionRef")]
    public string ExternalTransactionRef { get; set; }

    [JsonPropertyName("merchantId")]
    public string MerchantId { get; set; }

    [JsonPropertyName("terminalId")]
    public string TerminalId { get; set; }

    [JsonPropertyName("amount")]
    public long Amount { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("transactionRefTimestamp")]
    public DateTime TransactionRefTimestamp { get; set; }

    [JsonPropertyName("openBPStatus")]
    public long OpenBPStatus { get; set; }
}

public class SalesResponse
{
    [JsonPropertyName("salesId")]
    public long SalesId { get; set; }

    [JsonPropertyName("billReference")]
    public string BillReference { get; set; }

    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [JsonPropertyName("grossAmount")]
    public decimal GrossAmount { get; set; }

    [JsonPropertyName("discount")]
    public Discount Discount { get; set; }

    [JsonPropertyName("salesItems")]
    public List<SalesItem> SalesItems { get; set; }
}

public class SalesItem
{
    [JsonPropertyName("productId")]
    public long ProductId { get; set; }

    [JsonPropertyName("productName")]
    public string ProductName { get; set; }

    [JsonPropertyName("balanceTypeId")]
    public long BalanceTypeId { get; set; }

    [JsonPropertyName("balanceType")]
    public BalanceType BalanceType { get; set; }

    [JsonPropertyName("quantity")]
    public decimal Quantity { get; set; }

    [JsonPropertyName("grossAmount")]
    public decimal GrossAmount { get; set; }

    [JsonPropertyName("unitAmount")]
    public decimal UnitAmount { get; set; }

    [JsonPropertyName("discount")]
    public Discount Discount { get; set; }

    [JsonPropertyName("prdvId")]
    public long PrdvId { get; set; }
}

public class BalanceType
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("softMinBalance")]
    public long SoftMinBalance { get; set; }

    [JsonPropertyName("softMaxBalance")]
    public long SoftMaxBalance { get; set; }

    [JsonPropertyName("hardMinBalance")]
    public long HardMinBalance { get; set; }

    [JsonPropertyName("hardMaxBalance")]
    public long HardMaxBalance { get; set; }

    [JsonPropertyName("softMinBalanceDisplay")]
    public string SoftMinBalanceDisplay { get; set; }

    [JsonPropertyName("softMaxBalanceDisplay")]
    public string SoftMaxBalanceDisplay { get; set; }

    [JsonPropertyName("hardMinBalanceDisplay")]
    public string HardMinBalanceDisplay { get; set; }

    [JsonPropertyName("hardMaxBalanceDisplay")]
    public string HardMaxBalanceDisplay { get; set; }

    [JsonPropertyName("currencyCode")]
    public string CurrencyCode { get; set; }

    [JsonPropertyName("balanceCategory")]
    public string BalanceCategory { get; set; }

    [JsonPropertyName("fractionSize")]
    public int FractionSize { get; set; }

    [JsonPropertyName("colour")]
    public string Colour { get; set; }

    [JsonPropertyName("mtrcId")]
    public long MtrcId { get; set; }

    [JsonPropertyName("metric")]
    public Metric Metric { get; set; }
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
    public decimal DisplayDivisor { get; set; }

    [JsonPropertyName("displayUnitDelimiter")]
    public string DisplayUnitDelimiter { get; set; }

    [JsonPropertyName("displayUnitMinorDelimiter")]
    public string DisplayUnitMinorDelimiter { get; set; }

    [JsonPropertyName("displayFormatter")]
    public string DisplayFormatter { get; set; }
}

public class Discount
{
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("rate")]
    public decimal Rate { get; set; }
}
