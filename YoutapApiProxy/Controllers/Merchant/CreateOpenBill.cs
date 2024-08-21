using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct Merchant
{
    // OK
    [ProducesResponseType(typeof(CreateOpenBillResponseModel.Root), (int)HttpStatusCode.OK)]
    // [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(WebhookExample))]

    // Request Body
    [Consumes(typeof(CreateOpenBillRequestModel.Root), MediaTypeNames.Application.Json)]

    [SwaggerOperation(Summary = "Create Open Bill (with Dynamic QR Code)", Description = @"
This request gets a string representation of a QR code that contains payment information that another user can scan to initiate a payment.")]
    public static IResult CreateOpenBill(string accountId)
    {
        var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
        return Results.Text(result, MediaTypeNames.Application.Json);
    }

}
