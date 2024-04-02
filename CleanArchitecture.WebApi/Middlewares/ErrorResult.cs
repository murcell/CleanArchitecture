namespace CleanArchitecture.WebApi.Middlewares;

public sealed class ErrorResult: ErrorStatusCode
{
    public string Message { get; set; }
}

