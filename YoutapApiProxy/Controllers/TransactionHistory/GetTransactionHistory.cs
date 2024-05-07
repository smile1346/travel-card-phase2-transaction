using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using System.Web;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using System.ComponentModel;
using HttpRequests;
using Newtonsoft.Json.Converters;

namespace Controllers;

public enum SortDirection
{
    ASC,
    DESC
}
readonly partial struct TransactionHistory
{
    // OK
    [ProducesResponseType(typeof(GetTransactionHistoryResponse.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetTransactionHistoryResponseExample))]
    // Internal Server Error
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]

    [SwaggerOperation(Summary = "Get Transaction History", Description = @"This endpoint retrieves the transaction history summary of an account filtering using the period [from - to] , sort direction and ordering property")]
    public static async Task GetTransactionHistory(HttpContext context,
    BBLClientBasedAccessTokenClient tokenClient,
    /* [DefaultValue("1040")] */[SwaggerParameter("The ID of the customer.")] string customerId,
    /* [DefaultValue("1021")] */[SwaggerParameter("The ID of the account.")] string accountId,
    // [SwaggerParameter("This is the category in which the account belongs to for example SAVINGS, LOAN , Biller Account , Agent Account")] string? accountType,
    // [SwaggerParameter("The type of the client (FINERACT, YTS).")] string? clientType,
    // [SwaggerParameter("The IDs of the accounts.")] string? accountIds,
    [SwaggerParameter("The end date-time of the transaction history range\n\nFormat: ISO datetime with timezone and optional precision: 2024-04-15T00:00:00.000+07:00")] string? to,
    [SwaggerParameter("The start date-time of the transaction history range\n\nFormat: ISO datetime with timezone and optional precision: 2024-03-20T23:59:59.999+07:00")] string? from,
    [SwaggerParameter("Search by an external reference if it was provided in the original transaction.")] string? requestReference,
    [SwaggerParameter("The number of transactions to retrieve per page.")] int? pageSize,
    [SwaggerParameter("The page number.")] int? page,
    [SwaggerParameter("The property to order by. Example: `txnlid`")] string? orderProperty,
    [FromQuery][SwaggerParameter("The direction of sorting")] SortDirection? sortDirection,
    // [SwaggerParameter("Indicates whether to include interest and tax transactions.")] bool? includeInterestAndTaxTransactions,
    [DefaultValue("EN")][FromHeader(Name = "Accept-Language")] string? acceptLanguage,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.\n\n**Empty payload must be signed for GET requests**")] string signature)
    {
        await AuthorizedHttpClient.RerouteWithAccessTokenWriteBodyAsync($"/history/wallet/v4/{customerId}/{accountId}/summary", context, tokenClient);
    }
}
