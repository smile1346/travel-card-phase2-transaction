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

namespace Handlers;

readonly struct CustomerWalletProfile
{
    // OK
    [ProducesResponseType(typeof(CustomerCreateResponsePayload), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Provision new customer wallet profile")]
    public static IResult Create(ModelsYoutap.CustomerAccountInfo payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        return Results.Ok();
    }

    [SwaggerOperation(Summary = "Retrieve customer wallet profile")]
    [ProducesResponseType(typeof(CustomerCreateRequestPayload), (int)HttpStatusCode.OK)]
    public static IResult Get(Guid customerWalletProfileId)
    {
        return Results.Ok();
    }

    [SwaggerOperation(Summary = "Update KYC details")]
    public static IResult UpdateKyc(Guid customerWalletProfileId, CustomerUpdateRequestPayload payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        return Results.Ok();
    }

    [SwaggerOperation(Summary = "Setup PIN")]
    public static IResult CreatePin(Guid customerWalletProfileId, PinCreateRequestPayload payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        return Results.Ok();
    }

    [SwaggerOperation(Summary = "Update PIN")]
    public static IResult UpdatePin(Guid customerWalletProfileId, PinUpdateRequestPayload payload /*[FromHeader(Name = "x-jws-signature")] [SwaggerParameter("JSON Web Signature (JWS) used for message integrity verification.")] string signature*/)
    {
        return Results.Ok();
    }
}
