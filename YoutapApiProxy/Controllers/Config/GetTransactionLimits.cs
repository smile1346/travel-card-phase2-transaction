using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct Config
{
    // OK
    [ProducesResponseType(typeof(GetTransactionLimitsResponseModel.Root[]), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetTransactionLimitsResponseExample))]
    [SwaggerOperation(Summary = "Get Transaction Limits", Description = @"
The credit transfer charges periodic limits, individual transaction limits, and whether the transaction type is allowed at all for that customer or account type.

sumDay: The maximum amount of money that can be transferred per day

sumMonth: The maximum amount of money that can be transferred per month

crtcLower: The minimum value of each transaction

crtcUpper: The maximum value of each transaction

enabled: Whether charge is enforced or not

display: Whether the charge should be displayed on-screen")]
    public static IResult GetTransactionLimits()
    {
        var res = File.ReadAllText(@"examples\GetTransactionLimitsResponse.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }

}
