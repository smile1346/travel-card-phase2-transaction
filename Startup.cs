using System.Text.Json;
using HttpRequests;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton(new DefaultAccessTokenClient());
builder.Services.AddSingleton(new BBLClientBasedAccessTokenClient());
builder.Services.AddSingleton(new PasswordBasedAccessTokenClient());
// builder.WebHost.ConfigureKestrel(o => o.AddServerHeader = false);

Security.AddJwt(builder);
Security.AddAuthorization(builder);
Security.AddCors(builder);

Documentation.AddSwagger(builder);

Monitoring.AddOpenTelemetry(builder);
Monitoring.AddLogging(builder, false);

var app = builder.Build();
Configuration.AddConfiguration(app);

app.MapPost("/oauth2/token", () =>
{
    return JsonSerializer.Serialize(new { expiresIn = "3600" }); ;
});

Router.AddRoutes(app);
app.Run();
