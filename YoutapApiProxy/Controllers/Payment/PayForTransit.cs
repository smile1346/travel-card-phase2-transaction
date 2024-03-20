using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using HttpRequests;
using System.Text;

namespace Controllers;

readonly partial struct Payment
{
    // OK
    [ProducesResponseType(typeof(BillPaymentResponseSuccessModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(BillPaymentResponseSuccessExample))]
    // Accepted
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.Accepted)]
    [SwaggerResponseExample((int)HttpStatusCode.Accepted, typeof(BillPaymentResponseDelayedExample))]
    // Bad Request
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.BadRequest)]
    [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(BillPaymentResponseInsufficientFundsExample))]
    // Internal Server Error
    [ProducesResponseType(typeof(ServerErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]
    // Request Body
    [Consumes(typeof(BillPaymentRequestModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(BillPaymentRequestModel.Root), typeof(BillPaymentRequestExample))]

    [SwaggerOperation(Summary = "Make transit payment", Description = @"
A consumer's balance can be used to pay bills for companies that are integrated into the wallet payment system. This could be internet, gas, phone, or many other types of bills. Generally all the user needs to do is select the provider they wish to pay and a list of the services they provide will be displayed. They can select the product they wish to pay for and the amount they need to pay will be loaded into the payment interface automatically.

As with P2P payments a PIN is required to help prevent fraud, and a delay can be specified in case the customer wishes to arrange the payment before the bill is due.

To send a bill payment, an app will usually get the list of providers first (see Get Biller Providers), which provides the values for the biller, external biller, and product identifiers according to what the customer selects. Additional fields may be required according to the type of product selected.")]
    public static async Task<string> PayForTransit(HttpContext context,
    PasswordBasedAccessTokenClient tokenClient,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.")] string signature)
    {
        return await AuthorizedHttpClient.RerouteWithAccessTokenReturnStringAsync("/emoney/v3/billpayment", context, tokenClient);
    }
}
