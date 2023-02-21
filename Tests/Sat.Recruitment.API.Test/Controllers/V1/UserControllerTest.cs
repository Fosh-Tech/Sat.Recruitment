using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.Controllers.V1;

namespace Sat.Recruitment.API.Test.Controllers.V1
{
    public  class UserControllerTest
    {
        Mock<ISender> _sender;
        UserController _controller;

        public UserControllerTest()
        {
            _sender = new Mock<ISender>();
            _controller = new UserController(_sender.Object);
        }

        [Fact]
        public async Task GetAllAsync_Should_Not_Returns_NotNull()
        {
            // Act
            var result = await _controller.GetAllAsync();

            // Assert
            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetAsync_Should_Not_Returns_NotNull()
        {
            // Act
            var result = await _controller.GetAsync(It.IsAny<string>());

            // Assert
            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result.Result);
        }    
    }
}
