using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct TransactionHistory
{
    // OK
    [ProducesResponseType(typeof(GetTransactionHistoryResponse.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetTransactionHistoryResponseExample))]

    [SwaggerOperation(Summary = "Get Transaction History", Description = @"This endpoint retrieves the transaction history summary of an account filtering using the period [from - to] , sort direction and ordering property")]
    public static IResult GetTransactionHistory(
    [SwaggerParameter("The ID of the customer.")] string custId,
    [SwaggerParameter("The ID of the account.")] string accountId,
    [SwaggerParameter("The type of the account.")] string accountType,
    [SwaggerParameter("The type of the client.")] string clientType,
    [SwaggerParameter("The IDs of the accounts.")] string accountIds,
    [SwaggerParameter("The end date of the transaction history range.")] string to,
    [SwaggerParameter("The start date of the transaction history range.")] string from,
    [SwaggerParameter("The size of each page.")] string pageSize,
    [SwaggerParameter("The page number.")] string page,
    [SwaggerParameter("The property to order by.")] string orderProperty,
    [SwaggerParameter("The direction of sorting (ascending or descending).")] string sortDirection,
    [SwaggerParameter("Indicates whether to include interest and tax transactions.")] string includeInterestAndTaxTransactions)
    {
        var res = File.ReadAllText(@"examples\GetTransactionHistoryResponse.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }
}
