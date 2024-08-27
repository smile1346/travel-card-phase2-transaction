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
    [SwaggerRequestExample(typeof(CreateOpenBillRequestModel.Root), typeof(CreateOpenBillRequestExample))]

    [SwaggerOperation(Summary = "Create Merchant Dynamic QR Code (Open Bill)", Description = @"
This request gets a string representation of a QR code that contains payment information that another user can scan to initiate a payment.")]
    public static IResult CreateOpenBill(
    [SwaggerParameter("The `Account Number` of the merchant, as shown in CMS portal.")] string accountId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature)
    {
        var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
        return Results.Text(result, MediaTypeNames.Application.Json);
    }

}
