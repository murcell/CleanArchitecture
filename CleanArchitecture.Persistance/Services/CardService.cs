using AutoMapper;
using CleanArchitecture.Application.Feature.Cars.Commands.Create;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistance.Services
{
    public sealed class CardService : ICarService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CardService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Createasync(CreateCarCommand request,CancellationToken cancellationToken)
        {
            //Car car = new Car()
            //{
            //    Name = request.name,
            //    Model = request.model,
            //    EnginePower = request.enginePower
            //};

            Car car = _mapper.Map<Car>(request);
            await _context.Set<Car>().AddAsync(car,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
