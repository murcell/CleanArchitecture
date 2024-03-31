
namespace CleanArchitecture.WebApi.Middlewares
{
    public sealed class ErrorMiddlewaare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{



				throw;
			}
        }
    }
}
