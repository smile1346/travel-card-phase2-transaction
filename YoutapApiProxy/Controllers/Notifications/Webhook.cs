using Microsoft.AspNetCore.Mvc;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

using Swashbuckle.AspNetCore.Filters;
using Examples;
using System.Net.Mime;
using HttpRequests;

namespace Controllers;

readonly partial struct Notifications
{
    // OK
    [ProducesResponseType(typeof(WebhookModel.Root), (int)HttpStatusCode.OK)]
    [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(WebhookExample))]

    [SwaggerOperation(Summary = "Webhook Examples", Description = @"Examples of webhook requests that will be sent to partner's callback url upon specific events.")]
    public static IResult Webhook()
    {
        var result = File.ReadAllText(@"examples/Webhook_LowBalance.json");
        return Results.Text(result, MediaTypeNames.Application.Json);
    }

}
