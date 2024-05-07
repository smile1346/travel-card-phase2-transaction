using Microsoft.IdentityModel.Tokens;

readonly struct IgnoreMissingHeaderMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    readonly List<string> ignoredHeaders = ["x-jws-signature", "Idempotency-Key"];

    public async readonly Task Invoke(HttpContext context)
    {
        ignoredHeaders.ForEach(header =>
        {
            if (context.Request.Headers[header].IsNullOrEmpty())
                context.Request.Headers[header] = string.Empty;
        });

        await _next(context);
    }

}
