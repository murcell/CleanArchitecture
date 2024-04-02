using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Entities;

public sealed class ErrorLog:Entity<long>
{
    public string ErrorMessage { get; set; }
    public string StackTrace { get; set; }
    public string Requestpath { get; set; }
    public string RequestMethod { get; set; }
    public DateTime Timestamp { get; set; }
}
