using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct Merchant
{
    // Created
    [ProducesResponseType(typeof(CreateOpenBillResponseModel.Root), (int)HttpStatusCode.Created)]
    [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(CreateOpenBillResponseExample))]

    // Request Body
    [Consumes(typeof(CreateOpenBillRequestModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(CreateOpenBillRequestModel.Root), typeof(CreateOpenBillRequestExample))]

    [SwaggerOperation(Summary = "[C-scan-B] Create Merchant-Presented Mode (MPM) QR Code (Open Bill)", Description = @"
This request gets a string representation of a QR code that contains payment information that another user can scan to initiate a payment.")]
    public static IResult CreateOpenBill(
    [SwaggerParameter("The `Customer Number` of the merchant, as shown in CMS portal.")] string merchantId,
    [SwaggerParameter("The `Account Number` of the merchant, as shown in CMS portal.")] string accountId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature)
    {
        var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
        return Results.Text(result, MediaTypeNames.Application.Json);
    }

}
