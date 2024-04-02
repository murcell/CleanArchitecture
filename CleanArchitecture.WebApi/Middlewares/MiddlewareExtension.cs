namespace CleanArchitecture.WebApi.Middlewares
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMiddleWareExtension(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}
