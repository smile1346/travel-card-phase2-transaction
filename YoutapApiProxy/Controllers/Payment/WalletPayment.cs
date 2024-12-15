using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using System.ComponentModel;
using HttpRequests;
using System.Text.Json;
using System.Text;

namespace Controllers;

readonly partial struct Payment
{
    // OK
    [ProducesResponseType(typeof(GeneralTransactionResponseSuccessModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(WalletPaymentResponseSuccessExample))]

    // Internal Server Error
    [ProducesResponseType(typeof(ClientErrorResponseModel.Root), (int)HttpStatusCode.InternalServerError)]

    // Request Body
    [Consumes(typeof(GeneralTransactionRequestModel.Root), MediaTypeNames.Application.Json)]
    [SwaggerRequestExample(typeof(GeneralTransactionRequestModel.Root), typeof(WalletPaymentRequestExample))]
    [SwaggerOperation(Summary = "Make wallet payment for goods", Description = @"
Performs a payment transaction that transfers funds from the customer's account to the merchant's account.

This is used when the customer provides a physical card to the merchant for in-person payments or when making payments through online services.

`C2MP`: Customer to Merchant Payment. The transaction goes from the merchant to the customer.")]
    public static async Task PayForGoods(HttpContext context,
    BBLClientBasedAccessTokenClient tokenClient,
    [DefaultValue("EN")][FromHeader(Name = "Accept-Language")] string? acceptLanguage,
    [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature,
    [FromHeader(Name = "Idempotency-Key")][SwaggerParameter("Unique key that the server uses to recognize subsequent retries of the same request to avoid the accidental creation of duplicate transactions.")] string idempotencyKey)
    {
        // using var reader = new StreamReader(context.Request.Body);
        // var str = await reader.ReadToEndAsync();

        // var body = JsonSerializer.Deserialize<BillPaymentRequestModel.Root>(str);

        // if (body?.ProductId == "et")
        // {
        //     context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //     context.Response.ContentType = MediaTypeNames.Application.Json;
        //     return JsonSerializer.Serialize(new { detail = "productId can't be `et` for wallet payment", errorDescription = "invalid product id" });
        // }

        // context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(str));
        await AuthorizedHttpClient.RerouteWithAccessTokenWriteBodyAsync("/emoney/v3/billpayment", context, tokenClient);
    }

}
