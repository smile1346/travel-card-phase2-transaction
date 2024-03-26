using System.Text.Json;
using HttpRequests;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton(new DefaultAccessTokenClient("a8331856-1f47-472a-9124-1af945ede46a", "b7158cb2-0b34-451b-9d47-0302d3eec273"));
builder.Services.AddSingleton(new BBLClientBasedAccessTokenClient("rabbit-client-1", "626fb86d-52d9-42e3-bcb6-b6f4e5d4918b"));
builder.Services.AddSingleton(new PasswordBasedAccessTokenClient("rabbit-consumer-1", "cf55af0a-3931-4e38-9830-b117778b2a7b"));
// builder.WebHost.ConfigureKestrel(o => o.AddServerHeader = false);

Security.AddJwt(builder);
Security.AddAuthorization(builder);
Security.AddCors(builder);

Documentation.AddSwagger(builder);

// Monitoring.AddOpenTelemetry(builder);
// Monitoring.AddLogging(builder, false);

var app = builder.Build();
Configuration.AddConfiguration(app);

app.MapPost("/oauth2/token", () =>
{
    return JsonSerializer.Serialize(new { expiresIn = "3600" }); ;
});

Router.AddRoutes(app);
app.Run();
