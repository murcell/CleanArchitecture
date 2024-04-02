
using System.ComponentModel.DataAnnotations;
using System.Net;
using FluentValidation;
using CleanArchitecture.WebApi.Middlewares;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;


namespace CleanArchitecture.WebApi.Middlewares
{
    public sealed class ExceptionMiddleware : IMiddleware
    {
        private readonly AppDbContext _context;

        public ExceptionMiddleware(AppDbContext context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next(context);
			}
			catch (Exception ex)
            {
                await LogExceptionToDatabaseAsync(ex, context.Request);
                await HandleExceptionAsync(context, ex);

            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            if (ex.GetType() == typeof(FluentValidation.ValidationException))
            {
                var validationErros = new ValidationErrorDetails
                {
                    Errors = ((FluentValidation.ValidationException)ex).Errors.Select(x => x.PropertyName),
                    StatusCode = 403
                };

                return context.Response.WriteAsync(validationErros.ToString());
            }

            return context.Response.WriteAsync(new ErrorResult
            {
                Message = ex.Message,
                StatusCode = context.Response.StatusCode,

            }.ToString());
        }

        private async Task LogExceptionToDatabaseAsync(Exception ex,HttpRequest request)
        {
            ErrorLog errorLog = new()
            {
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace,
                Requestpath = request.Path,
                RequestMethod=request.Method,
                Timestamp=DateTime.Now
            };

            await _context.Set<ErrorLog>().AddAsync(errorLog, default);
            await _context.SaveChangesAsync();
        }
    }
}
