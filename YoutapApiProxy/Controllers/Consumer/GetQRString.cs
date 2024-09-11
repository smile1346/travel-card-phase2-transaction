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
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetQRStringResponseExample))]

    [SwaggerOperation(Summary = "[B-scan-C] Create Consumer-Presented Mode (CPM) QR Code", Description = @"
This request gets a string representation of a QR code that contains payment information that another user can scan to initiate a payment.")]
    public static IResult GetQRString(
    [SwaggerParameter("The `Customer Number` of the customer, as shown in CMS portal.")] string customerId,
    [SwaggerParameter("The `Account Number` of the customer, as shown in CMS portal.")] string accountId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature)
    {
        var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
        return Results.Text(result, MediaTypeNames.Application.Json);
    }

}
