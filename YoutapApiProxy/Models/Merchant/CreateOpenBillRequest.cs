using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace CreateOpenBillRequestModel;
public class Root
{
    [Required]
    [JsonPropertyName("merchantId")]
    [SwaggerSchema("The `Customer Number` of the merchant, as shown in CMS portal.")]
    public string MerchantId { get; set; }

    [Required]
    [JsonPropertyName("terminalId")]
    [SwaggerSchema("ID of the device that initiated the payment, use `API` if unknown.")]
    public string TerminalId { get; set; }

    [Required]
    [JsonPropertyName("transactionAmount")]
    public decimal TransactionAmount { get; set; }

    [Required]
    [JsonPropertyName("currency")]
    public string Currency { get; set; }

    [Required]
    [JsonPropertyName("billReference")]
    public string BillReference { get; set; }

    [JsonPropertyName("feeOrTip")]
    public string FeeOrTip { get; set; }

    [JsonPropertyName("customerName")]
    public string CustomerName { get; set; }

    [JsonPropertyName("customerMsisdn")]
    public string CustomerMsisdn { get; set; }

    [SwaggerSchema("QR code validity period in seconds, defaults to 15s")]
    [JsonPropertyName("validityPeriod")]
    public long ValidityPeriod { get; set; }

    [JsonPropertyName("discount")]
    public Discount Discount { get; set; }

    [JsonPropertyName("items")]
    public List<Item> Items { get; set; }

    [JsonPropertyName("billableEvent")]
    public long BillableEvent { get; set; }

    [JsonPropertyName("imageId")]
    public string ImageId { get; set; }

    [JsonPropertyName("balanceTypeId")]
    public long BalanceTypeId { get; set; }
}

public class Discount
{
    [JsonPropertyName("amount")]
    public decimal Amount { get; set; }

    [JsonPropertyName("rate")]
    public decimal Rate { get; set; }
}

public class Item
{
    [JsonPropertyName("productId")]
    public long ProductId { get; set; }

    [JsonPropertyName("productName")]
    public string ProductName { get; set; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; set; }

    [JsonPropertyName("discount")]
    public Discount Discount { get; set; }

    [JsonPropertyName("unitAmount")]
    public decimal UnitAmount { get; set; }

    [JsonPropertyName("grossAmount")]
    public decimal GrossAmount { get; set; }

    [JsonPropertyName("balanceTypeId")]
    public long BalanceTypeId { get; set; }

    [JsonPropertyName("prdvId")]
    public long PrdvId { get; set; }
}
