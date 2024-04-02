namespace CleanArchitecture.WebApi.Middlewares;

public sealed class ValidationErrorDetails: ErrorStatusCode
{
    public IEnumerable<string> Errors { get; set; }
}

