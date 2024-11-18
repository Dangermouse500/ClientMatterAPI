using Client.Matter.API.Controllers;
using Client.Matter.Models.DTOs;
using Client.Matter.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;

namespace Client.Matter.API.UnitTests
{
    [TestClass]
    public class ClientControllerUnitTests
    {
        private readonly Mock<IClientService> _clientService;
        private readonly string _clientId = "123";
        private readonly ClientDto _clientDto;

        public ClientControllerUnitTests()
        {
            _clientService = new Mock<IClientService>();

            _clientDto = new ClientDto() { ClientId = "8", Code = "88888", Description = "Testing desc", Name = "John" };
            _clientService.Setup(x => x.GetClientByIdAsync(_clientId)).ReturnsAsync(_clientDto);
        }

        private ClientController CreateObjectUnderTest(Mock<IClientService> clientServiceMock)
        {
            return new ClientController(clientServiceMock.Object);
        }

        [TestMethod]
        public async Task GetClientByIdAsync_ReturnsClientSuccessfully()
        {
            //Arrange
            var objectUnderTest = CreateObjectUnderTest(_clientService);

            //Act
            var result = await objectUnderTest.GetClientByIdAsync(_clientId);

            //Assert
            result.ShouldBeOfType<OkObjectResult>();
            ((OkObjectResult)result).Value.ShouldBeAssignableTo<ClientDto>();
            ((ClientDto)((OkObjectResult)result).Value).ClientId.ShouldBe(_clientDto.ClientId);
            ((ClientDto)((OkObjectResult)result).Value).Code.ShouldBe(_clientDto.Code);
            ((ClientDto)((OkObjectResult)result).Value).Description.ShouldBe(_clientDto.Description);
            ((ClientDto)((OkObjectResult)result).Value).Name.ShouldBe(_clientDto.Name);
        }

        [TestMethod]
        public async Task GetClientByIdAsync_InvalidClientIdReturnsNotFound()
        {
            //Arrange
            var invalidClientId = "Broken one";
            var errorMessage = $"Client '{invalidClientId}' is not found.";
            var objectUnderTest = CreateObjectUnderTest(_clientService);

            //Act
            var result = await objectUnderTest.GetClientByIdAsync(invalidClientId);

            //Assert
            result.ShouldBeOfType<NotFoundObjectResult>();
            ((ProblemDetails)((ObjectResult)result).Value).Detail.ShouldBe(errorMessage);
        }
    }
}