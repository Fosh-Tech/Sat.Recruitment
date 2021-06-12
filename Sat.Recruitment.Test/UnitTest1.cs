
using System.Threading.Tasks;

using Sat.Recruitment.Api.Controllers;

using Xunit;

using Src = Sat.Recruitment.Api;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public async Task CreateUser_GivenAnyNewUser_OkExpected()
        {
            var userController = CreateController();

            var result = await userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");


            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public async Task CreateUser_GivenAnyAlreadyExistingUser_UserDuplicatedErrorExpected()
        {
            var userController = CreateController();

            var result = await userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124");


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        // TODO: Use an xUnit Fixture instead.
        private static UsersController CreateController()
        {
            return new UsersController(
                Src.Model.Validators.Default.Create(),
                Src.Domain.Promotions.Default.Create(),
                Src.Domain.Repositories.Default.Create());
        }
    }
}
