using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Application.Configuration;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Dto.Dtos;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserTests
    {

        private UsersController _userController;

        public UserTests()
        {
            var services = new ServiceCollection();

            services.AddApplicationServices();

            var provider = services.BuildServiceProvider();

            _userController = new UsersController(provider.GetService<IUserService>());
        }

        [Fact]
        public async Task Test1()
        {
            var dto = new UserDto
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            var result = (await _userController.CreateUser(dto)) as ObjectResult;
            var response = result.Value as ResultDto;

            Assert.True( result.StatusCode == ((int)HttpStatusCode.OK) &&
                response.IsSuccess && 
                response.Messages.Count == 1 &&
                response.Messages.Any(m => m == "User Created"));
        }

        [Fact]
        public async Task Test2()
        {
            var dto = new UserDto
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            var result = (await _userController.CreateUser(dto)) as ObjectResult;
            var response = result.Value as ResultDto;

            Assert.True(result.StatusCode == ((int)HttpStatusCode.BadRequest) &&
                !response.IsSuccess &&
                response.Messages.Count == 1 &&
                response.Messages.Any(m => m == "The user is duplicated"));
        }
    }
}
