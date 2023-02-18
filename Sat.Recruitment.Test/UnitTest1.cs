using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Api.Controllers;
using Xunit;
using Xunit.Abstractions;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1: IClassFixture<DataFixture>, IClassFixture<LoggerFixture>
    {
        private readonly DataFixture _dataFixture;
        private readonly ITestOutputHelper _output;
        private readonly ILogger<UsersController> _logger;

        public UnitTest1(DataFixture dataFixture, LoggerFixture loggerFixture, ITestOutputHelper testOutputHelper)
        {
            _dataFixture = dataFixture;
            _logger = loggerFixture.Factory.CreateLogger<UsersController>();
            _output = testOutputHelper;
        }
        [Fact]
        public void Test1()
        {
            var userController = new UsersController(_dataFixture.Data, _logger);
            
            var response = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");

            Assert.True(response.Result is OkObjectResult);
            var value = (Result)((OkObjectResult)response.Result).Value;
            Assert.True(value is not null);
            Assert.True(value.IsSuccess);
            Assert.Equal("User Created", value.Errors);
            _output.WriteLine("Sugiero rediseñar la API para que sea REST.");
        }

        [Fact]
        public void Test2()
        {
            var userController = new UsersController(_dataFixture.Data, _logger);
            
            var response = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");

            Assert.True(response.Result is BadRequestObjectResult);
            var value = (Result)((BadRequestObjectResult)response.Result).Value;
            Assert.True(value is not null);
            Assert.False(value.IsSuccess);
            Assert.Equal("The user is duplicated", value.Errors);
            _output.WriteLine("Sugiero rediseñar la API para que sea REST.");
        }
    }
}
