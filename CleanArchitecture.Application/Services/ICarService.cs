using CleanArchitecture.Application.Feature.Cars.Commands.Create;

namespace CleanArchitecture.Application.Services;

public interface ICarService
{
    Task Createasync(CreateCarCommand request, CancellationToken cancellationToken);
}
