using AutoMapper;
using CleanArchitecture.Application.Feature.Cars.Commands.Create;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Profiles;

public sealed class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCarCommand,Car>().ReverseMap();
    }
}
