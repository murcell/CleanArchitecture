using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Feature.Cars.Commands.Create;

public sealed record CreateCarCommand(string name, string model, int enginePower):IRequest<MessageResponse>;

