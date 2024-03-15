using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using Models;
using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct TransactionHistory
{
    // OK
    [ProducesResponseType(typeof(GetPendingDelayedPaymentsResponseModel.Root[]), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(BillPaymentResponseSuccessExample))]

    [SwaggerOperation(Summary = "Get Pending Delayed Payments", Description = @"This endpoint retrieves unprocessed delayed payments.")]
    public static IResult GetPendingDelayedPayments([SwaggerParameter("The ID of the customer.")] string custId)
    {
        var res = File.ReadAllText(@"examples\BillPaymentResponse_Successful.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }

}
