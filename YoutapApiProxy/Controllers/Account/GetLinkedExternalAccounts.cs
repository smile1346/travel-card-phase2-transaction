using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using HttpRequests;

namespace Controllers;

readonly partial struct Account
{
    // OK
    [ProducesResponseType(typeof(GetLinkedExternalAccountsResponseModel.Root[]), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(GetLinkedExternalAccountsResponseExample))]

    [SwaggerOperation(Summary = "Get linked external accounts", Description = @"""External accounts"" can be linked to a customer's wallet through the Customer Management System. The wallet can then see which accounts have been linked using this endpoint.")]
    public static async Task GetLinkedExternalAccounts(
        HttpContext context,
        BBLClientBasedAccessTokenClient tokenClient,
        [SwaggerParameter("The ID of the customer.")] string customerId,
        [FromHeader(Name = "x-jws-signature")][SwaggerParameter("JSON Web Signature with detached payload (JWS-Detached) used for message integrity verification.\n\n**Empty payload must be signed for GET requests**")] string signature)
    {
        await AuthorizedHttpClient.RerouteWithAccessTokenWriteBodyAsync($"/customers/v2/{customerId}/linked-external-accounts", context, tokenClient);
    }

}
