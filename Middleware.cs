using Microsoft.IdentityModel.Tokens;

readonly struct IgnoreMissingHeaderMiddleware(RequestDelegate next)
{
    readonly List<string> ignoredHeaders = ["x-jws-signature", "Idempotency-Key"];

    public async readonly Task Invoke(HttpContext context)
    {
        ignoredHeaders.ForEach(header =>
        {
            if (context.Request.Headers[header].IsNullOrEmpty())
                context.Request.Headers[header] = string.Empty;
        });

        await next(context);
    }

}
