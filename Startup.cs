using System.Text.Json.Serialization;
using HttpRequests;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton(new DefaultAccessTokenClient());
builder.Services.AddSingleton(new BBLClientBasedAccessTokenClient());
builder.Services.AddSingleton(new PasswordBasedAccessTokenClient());
builder.WebHost.ConfigureKestrel(o => o.AddServerHeader = false);

Security.AddJwt(builder);
Security.AddAuthorization(builder);
Security.AddCors(builder);

Documentation.AddSwagger(builder);

Monitoring.AddOpenTelemetry(builder);
Monitoring.AddLogging(builder);

var app = builder.Build();
Configuration.AddConfiguration(app);

app.MapPost("/oauth2/token", () =>
{
    return new TokenResponse
    {
        AccessToken = "",
        ExpiresIn = "300",
        IssuedAt = DateTime.Now.ToString()
    };
});
Router.AddRoutes(app);
app.Run();

struct TokenResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken;
    [JsonPropertyName("expires_in")]
    public string ExpiresIn;
    [JsonPropertyName("issued_at")]
    public string IssuedAt;
}
