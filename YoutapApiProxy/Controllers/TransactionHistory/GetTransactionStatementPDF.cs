using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using Examples;

namespace Controllers;

readonly partial struct TransactionHistory
{
    // OK
    // [ProducesResponseType(typeof(GetTransactionHistoryResponse.Root), (int)HttpStatusCode.OK)]
    // [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetTransactionHistoryResponseExample))]

    [SwaggerOperation(Summary = "Get Transaction Statement PDF", Description = @"Successful Statement Export for a Single Account")]
    public static IResult GetTransactionStatementPDF([SwaggerParameter("The ID of the customer.")] string custId, int YYYY, int MM, string accountId)
    {
        return Results.Ok();
    }

}
