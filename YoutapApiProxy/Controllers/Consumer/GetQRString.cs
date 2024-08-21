using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct Consumer
{
    // OK
    [ProducesResponseType(typeof(GetQRStringResponseModel.Root), (int)HttpStatusCode.OK)]
    // [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(WebhookExample))]

    [SwaggerOperation(Summary = "Get QR String", Description = @"
This request gets a string representation of a QR code that contains payment information that another user can scan to initiate a payment.")]
    public static IResult GetQRString(string customerId)
    {
        var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
        return Results.Text(result, MediaTypeNames.Application.Json);
    }

}
