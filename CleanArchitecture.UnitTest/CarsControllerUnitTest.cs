using CleanArchitecture.Application.Feature.Cars.Commands.Create;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.UnitTest
{
    public class CarsControllerUnitTest
    {
        [Fact]
        public async Task Create_ReturnOkResult_WhenRequestIsValidAsync()
        {
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            CreateCarCommand createCarCommand = new CreateCarCommand("Toyota", "Corolla", 125);
            MessageResponse response = new("Araç baþaýyla eklendi.");
            CancellationToken cancellationToken = new CancellationToken();

            mediatorMock.Setup(m => m.Send(createCarCommand, cancellationToken)).ReturnsAsync(response);
            CarsController carsController = new CarsController(mediatorMock.Object);

            //Act

            var result = await carsController.Create(createCarCommand, cancellationToken);

            //Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<MessageResponse>(okResult.Value);
            Assert.Equal(response, returnValue);

            mediatorMock.Verify(m=> m.Send(createCarCommand, cancellationToken),Times.Once);
        }
    }
}