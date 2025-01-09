using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct Merchant
{
    // No Content
    [ProducesResponseType((int)HttpStatusCode.NoContent)]

    // Bad Request
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.BadRequest)]
    [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(DeactivateOpenBillBadRequestExample))]

    // Request Body
    [Consumes(typeof(CreateOpenBillRequestModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(DeactivateOpenBillRequest.Root), typeof(DeactivateOpenBillRequestExample))]

    [SwaggerOperation(Summary = "[C-scan-B] Deactivate Merchant-Presented Mode (MPM) QR Code", Description = @"
This request deactivate a merchant's open bill using created QR code bill reference.")]
    public static IResult DeactivateOpenBill(
    [SwaggerParameter("The `Customer Number` of the merchant, as shown in CMS portal.")] string merchantId,
    [SwaggerParameter("The `Account Number` of the merchant, as shown in CMS portal.")] string accountId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature)
    {
        var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
        return Results.Text(result, MediaTypeNames.Application.Json);
    }

}
