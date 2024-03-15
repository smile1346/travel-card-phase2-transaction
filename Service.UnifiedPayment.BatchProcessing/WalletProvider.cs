using Dapr.Client;
using System.Text.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using Microsoft.CodeAnalysis.Sarif;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using Microsoft.CodeAnalysis.Sarif.Writers;
using Swashbuckle.AspNetCore.Filters;
using Models;
using System.Text.RegularExpressions;

namespace Handlers;

readonly struct WalletProvider
{
    // static readonly string pain002 = File.ReadAllText(@"examples/pain002.json");

    [SwaggerOperation(Summary = "Create new wallet provider")]
    // OK
    [ProducesResponseType(typeof(WalletProviderCreateResponsePayload), (int)HttpStatusCode.OK)]
    // [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(AnyGatewayResponseExamples))]
    // Unauthorized
    [ProducesResponseType(typeof(ErrorResponse.Root), (int)HttpStatusCode.Unauthorized)]
    [SwaggerResponseExample((int)HttpStatusCode.Unauthorized, typeof(UnauthorizedResponse))]
    // Internal Server Error
    [ProducesResponseType(typeof(ErrorResponse.Root), (int)HttpStatusCode.InternalServerError)]
    [SwaggerResponseExample((int)HttpStatusCode.InternalServerError, typeof(InternalServerErrorResponse))]
    // Request Body
    // [Consumes(typeof(ConfirmTransferRequest), MediaTypeNames.Application.Json)]
    // [SwaggerRequestExample(typeof(ConfirmTransferRequest), typeof(AccountValidationRequestExamples))]
    public static IResult CreateWalletProvider(WalletProviderCreateRequestPayload payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        return Results.Ok();
    }


    [SwaggerOperation(Summary = "Get information of a specified wallet provider")]
    [ProducesResponseType(typeof(WalletProviderCreateResponsePayload), (int)HttpStatusCode.OK)]
    public static IResult GetWalletProvider(Guid walletProviderId)
    {
        return Results.Ok();
    }

    [SwaggerOperation(Summary = "Get all wallet providers")]
    [ProducesResponseType(typeof(WalletProviderCreateResponsePayload[]), (int)HttpStatusCode.OK)]
    public static IResult GetWalletProviders(string filterName)
    {
        return Results.Ok();
    }
}
