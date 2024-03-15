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
using ModelsYoutap;
using QuickType;

namespace Handlers;

readonly struct WalletAccount
{
    // static readonly string pain002 = File.ReadAllText(@"examples/pain002.json");

    [SwaggerOperation(Summary = "Create a new wallet account")]
    // OK
    [ProducesResponseType(typeof(QuickAccount), (int)HttpStatusCode.OK)]
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
    public static IResult CreateWallet(WalletCreateRequestPayload payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        return Results.Ok();
    }

    [SwaggerOperation(Summary = "Get transaction details")]
    [ProducesResponseType(typeof(Content), (int)HttpStatusCode.OK)]
    public static IResult GetTransaction(Guid customerId, Guid walletAccountId, string transactionId)
    {
        return Results.Ok();
    }

    [SwaggerOperation(Summary = "Get transaction list")]
    [ProducesResponseType(typeof(TransactionHistory), (int)HttpStatusCode.OK)]
    public static IResult GetTransactionList(Guid walletAccountId, int pageSize, int page, string orderProperty, string sortDirection)
    {
        return Results.Ok();
    }

    [SwaggerOperation(Summary = "Get wallet account")]
    [ProducesResponseType(typeof(QuickAccount[]), (int)HttpStatusCode.OK)]
    public static IResult GetWallets(Guid customerId)
    {
        return Results.Ok();
    }
}
