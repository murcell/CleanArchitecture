﻿using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Feature.Cars.Commands.Create
{
    public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, MessageResponse>
    {
        private readonly ICarService _carService;

        public CreateCarCommandHandler(ICarService carService)
        {
            _carService = carService;
        }

        public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            await _carService.Createasync(request, cancellationToken);
            return new MessageResponse("Araç başaıyla eklendi.");
        }
    }
}
