using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using System.Text.Json.Serialization;

namespace Controllers
{

    readonly partial struct Consumer
    {
        // OK
        [ProducesResponseType(typeof(PayByMerchantTokenResponseModel.Root), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(PayByMerchantQRResponseExample))]

        // Bad Request
        [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.BadRequest)]
        [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(PayByMerchantQRResponseBadRequestExample))]

        // Request Body
        [Consumes(typeof(PayByMerchantTokenRequestModel.Root), MediaTypeNames.Application.Json)]
        [SwaggerRequestExample(typeof(PayByMerchantTokenRequestModel.Root), typeof(PayByMerchantQRRequestExample))]

        [SwaggerOperation(Summary = "[C-scan-B] Purchase By Scanning Merchant QR Code", Description = @"
Make a payment by scanning a QR code presented by a merchant. That QR code will contain the information required to fill in the request body.")]
        public static IResult PayByMerchantToken(
    [SwaggerParameter("The `Customer Number` of the customer, as shown in CMS portal.")] string customerId,
    [SwaggerParameter("The `Account Number` of the customer, as shown in CMS portal.")] string accountId,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature,
    [FromHeader(Name = "Idempotency-Key")][SwaggerParameter("Unique key that the server uses to recognize subsequent retries of the same request to avoid the accidental creation of duplicate transactions.")] string idempotencyKey)
        {
            var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
            return Results.Text(result, MediaTypeNames.Application.Json);
        }

    }
}