using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;

namespace Controllers;

readonly partial struct KYC
{
    // OK
    [ProducesResponseType(typeof(KYCConfirmationModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(KYCConfirmationResponseExample))]
    [SwaggerOperation(Summary = "KYC Confirmation", Description = @"Sends an OTP to the phone number, if valid. The validity period of the OTP is provided in the response.")]
    public static IResult KYCConfirmation()
    {
        var res = File.ReadAllText(@"examples\KYCConfirmationResponse.json");
        return Results.Text(res, MediaTypeNames.Application.Json);
    }

}
