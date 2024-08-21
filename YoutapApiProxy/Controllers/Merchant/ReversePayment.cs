using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using System.Text.Json.Serialization;
using HttpRequests;

namespace Controllers
{

    readonly partial struct Merchant
    {
        // No Content
        [ProducesResponseType((int)HttpStatusCode.NoContent)]

        // Not Found
        [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.NotFound)]
        [SwaggerResponseExample((int)HttpStatusCode.NotFound, typeof(ReversePaymentResponseExample))]

        // Request Body
        [Consumes(typeof(PaymentReversalRequestModel.Root), MediaTypeNames.Application.Json)]
        [SwaggerRequestExample(typeof(PaymentReversalRequestModel.Root), typeof(ReversePaymentRequestExample))]

        [SwaggerOperation(Summary = "Reverse Payment", Description = @"
Reverses an existing payment. Reversed payments are not included in settlement and will have a reference to the transaction that was created to perform the reversal.")]
        public static async Task ReversePayment(HttpContext context,
        BBLClientBasedAccessTokenClient tokenClient,
        [SwaggerParameter("The ID of the customer or merchant. (e.g. 140, 1041)")] string customerId,
        [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature)
        {
            await AuthorizedHttpClient.RerouteWithAccessTokenWriteBodyAsync($"/emoney/v3/merchants/{customerId}/reversal", context, tokenClient);
        }

    }
}