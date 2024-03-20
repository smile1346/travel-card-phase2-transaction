using HttpRequests;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton(new ClientCredentialsBasedAccessTokenClient());
builder.Services.AddSingleton(new PasswordBasedAccessTokenClient());
builder.WebHost.ConfigureKestrel(o => o.AddServerHeader = false);

Security.AddJwt(builder);
Security.AddAuthorization(builder);
Security.AddCors(builder);

Documentation.AddSwagger(builder);

var app = builder.Build();
Configuration.AddConfiguration(app);

Router.AddRoutes(app);
app.Run();
