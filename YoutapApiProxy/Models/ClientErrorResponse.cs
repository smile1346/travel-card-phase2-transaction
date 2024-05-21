using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace ClientErrorResponseModel;

public class Root
{
    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    [JsonPropertyName("errorCode")]
    [SwaggerSchema(@"| ErrorCode | ErrorKey | ErrorDescription |
|------|----------------|--------------|
| 1000     | transaction.resultcode.1  | Invalid From Account |
| 1001     | transaction.resultcode.2  | Invalid To Account |
| 1002     | transaction.resultcode.3  | Insufficient funds |
| 1003     | transaction.resultcode.4  | From Account is Suspended |
| 1004     | transaction.resultcode.5  | To Account is Suspended |
| 1005     | transaction.resultcode.6  | From Balance is Suspended |
| 1006     | transaction.resultcode.7  | To Balance is Suspended |
| 1007     | transaction.resultcode.8  | From Balance is Invalid |
| 1008     | transaction.resultcode.9  | To Balance is Invalid |
| 1009     | transaction.resultcode.10 | Payment Type is Invalid |
| 1010     | transaction.resultcode.11 | From Customer - not Found |
| 1011     | transaction.resultcode.12 | To Customer - not Found |
| 1012     | transaction.resultcode.13 | Amount is invalid |
| 1013     | transaction.resultcode.14 | From and To account are Identical |
| 1014     | transaction.resultcode.15 | Merchant Account is Invalid |
| 1015     | transaction.resultcode.16 | Merchant Account is Suspended |
| 1016     | transaction.resultcode.17 | Merchant Balance is Invalid |
| 1017     | transaction.resultcode.18 | Customer not Found |
| 1018     | transaction.resultcode.19 | No Parent for Fees and Charges |
| 1019     | transaction.resultcode.20 | Transaction is below minimum allowed value |
| 1020     | transaction.resultcode.21 | Transaction limit reached |
| 1021     | transaction.resultcode.22 | Daily limit reached |
| 1022     | transaction.resultcode.23 | Monthly limit reached |
| 1023     | transaction.resultcode.24 | System Account not Found |
| 1024     | transaction.resultcode.25 | No Commission Configured |
| 1025     | transaction.resultcode.26 | Balance limit reached |
| 1026     | transaction.resultcode.27 | Transaction type not allowed |
| 1027     | transaction.resultcode.28 | Transaction type not allowed for this account |
| 1028     | transaction.resultcode.29 | Total Daily limit reached |
| 1029     | transaction.resultcode.30 | Total Monthly limit reached |
| 1030     | transaction.resultcode.31 | Transaction type not allowed for the Balance |
| 1068     | transaction.resultcode.32 | Balance Locked for From Account |
| 1069     | transaction.resultcode.33 | Balance Locked for To Account |
| 1070     | transaction.resultcode.34 | Balance Locked for Commission |
| 1071     | transaction.resultcode.35 | Balance Locked for Distribution |
| 1103     | transaction.resultcode.36 | Source wallet type minimum transaction limit |
| 1104     | transaction.resultcode.37 | Destination wallet type minimum transaction limit |
| 1105     | transaction.resultcode.38 | Wallet type balance hard max limit |
| 1106     | transaction.resultcode.39 | Customer balance hard max limit |
| 201      | transaction.resultcode.40 | From Customer is Suspended |
| 202      | transaction.resultcode.41 | To Customer is Suspended |")]
    public string ErrorCode { get; set; }

    [JsonPropertyName("errorDescription")]
    public string ErrorDescription { get; set; }

    [JsonPropertyName("errorKey")]
    public string ErrorKey { get; set; }

    [JsonPropertyName("instance")]
    public string Instance { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}
