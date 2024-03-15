using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Models;
using Swashbuckle.AspNetCore.Filters;
using Examples;

namespace Controllers;

readonly partial struct TransactionHistory
{
    // OK
    // [ProducesResponseType(typeof(GetTransactionHistoryResponse.Root), (int)HttpStatusCode.OK)]
    // [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetTransactionHistoryResponseExample))]

    [SwaggerOperation(Summary = "Get Transaction Statement CSV", Description = @"This endpoint returns a similar set of data to the pdf version, however it is formatted more appropriately for consumption by spreadsheet software instead of human reading.")]
    public static IResult GetTransactionStatementCSV([SwaggerParameter("The ID of the customer.")] string custId, int YYYY, int MM, string accountId)
    {
        var res = File.ReadAllText(@"examples\GetTransactionStatementCSVResponse.csv");
        return Results.Text(res);
    }

}
