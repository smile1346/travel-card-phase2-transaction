using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using HttpRequests;
using System.ComponentModel.DataAnnotations;

namespace Controllers;

readonly partial struct Integration
{
    // OK
    [ProducesResponseType(typeof(GeneralTransactionResponseSuccessModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GeneralTransactionResponseSuccessExample))]
    // Bad Request
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.BadRequest)]
    [SwaggerResponseExample((int)HttpStatusCode.BadRequest, typeof(GeneralTransactionResponseErrorExample))]
    // Too Many Requests
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.TooManyRequests)]
    [SwaggerResponseExample((int)HttpStatusCode.TooManyRequests, typeof(GeneralTransactionResponseTooManyRequestsExample))]
    // Internal Server Error
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]
    // Request Body
    [Consumes(typeof(GeneralTransactionRequestModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(GeneralTransactionRequestModel.Root), typeof(GeneralTransactionRequestExample))]
    [SwaggerOperation(Summary = "Deposit / Withdrawal", Description = @"Performs a transaction that deposits money from the merchant's balance into the customer's account. Used when the customer gives physical cash to the merchant in order to top up their digital wallet.

This is the same operation (i.e. the requests are almost the same) as the withdrawal. The paymentType in the transactionDetails defines which direction the money goes.

C2MD: Customer to Merchant Deposit. The transaction goes from the merchant to the customer.

C2MW: Customer to Merchant Withdrawal. the transaction goes from the customer to the merchant.")]
    public static async Task DepositWithdrawal(HttpContext context,
    BBLClientBasedAccessTokenClient tokenClient,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.")] string signature,
    [FromHeader(Name = "Idempotency-Key")][SwaggerParameter("Unique key that the server uses to recognize subsequent retries of the same request to avoid the accidental creation of duplicate transactions.")] string idempotencyKey)
    {
        await AuthorizedHttpClient.RerouteWithAccessTokenWriteBodyAsync("/external-partners/v1/general-transaction", context, tokenClient);
    }

}
