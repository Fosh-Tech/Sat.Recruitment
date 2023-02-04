using System.Net;
using System.Threading.Tasks;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Application.Services;
using Xunit;

namespace Sat.Recruitment.Test.Controllers
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UsersControllerUnitTest
    {        
        [Fact]
        public async Task CreateUser_Normal_GivenAnyNewUser_OkExpected()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("Normal 1", "normal1@gmail.com", "Address Normal 1", "+34111111111", "Normal", "111");

            Assert.True(result.IsSuccess);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task CreateUser_SuperUser_GivenAnyNewUser_OkExpected()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("SuperUser 1", "superuser1@gmail.com", "Address SuperUser 1", "+34222222222", "Normal", "222");

            Assert.True(result.IsSuccess);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task CreateUser_Premium_GivenAnyNewUser_OkExpected()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("Premium 1", "premium1@gmail.com", "Address Premium 1", "+34333333333", "Premium", "333");

            Assert.True(result.IsSuccess);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public async Task CreateUser_GivenAnyAlreadyExistingUserByEmail_UserDuplicatedErrorExpected()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("Normal 1", "Juan@marmol.com", "Address Normal 1", "+34111111111", "Normal", "111");

            Assert.False(result.IsSuccess);
            Assert.Contains("The user is duplicated", result.Errors);
        }

        [Fact]
        public async Task CreateUser_GivenAnyAlreadyExistingUserByPhone_UserDuplicatedErrorExpected()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("Normal 1", "normal1@gmail.com", "Address Normal 1", "+5491154762312", "Normal", "111");

            Assert.False(result.IsSuccess);
            Assert.Contains("The user is duplicated", result.Errors);
        }

        [Fact]
        public async Task CreateUser_GivenAnyAlreadyExistingUserByNameAddress_UserDuplicatedErrorExpected()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("Juan", "Juan@marmol.com", "Peru 2464", "+34111111111", "Normal", "111");

            Assert.False(result.IsSuccess);
            Assert.Contains("The user is duplicated", result.Errors);
        }

        [Fact]
        public async Task CreateUser_CheckUserFieldsValidation_ErrorExpected()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser(null, null, null, null, "UserTypeInIncorrect", "NonParseableMoney");

            Assert.False(result.IsSuccess);
            Assert.Contains("The name is required", result.Errors);
            Assert.Contains("The email is required", result.Errors);
            Assert.Contains("The address is required", result.Errors);
            Assert.Contains("The phone is required", result.Errors);
            Assert.Contains("The userType is incorrect", result.Errors);
            Assert.Contains("The money value is not parseable", result.Errors);
        }

        [Fact]
        public async Task CreateUser_EmailIncorrectFormat_EmailFormatErrorException()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("Juan", "emailIncorrectFormat", "Peru 2464", "+5491154762312", "Normal", "1234");

            Assert.False(result.IsSuccess);
            Assert.Contains("The email cannot be normalized", result.Errors);
        }

        [Fact]
        public async Task CreateUser_EmailNull_EmailFormatException()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("Juan", null, "Peru 2464", "+5491154762312", "Normal", "1234");

            Assert.False(result.IsSuccess);
            Assert.Contains("The email is required", result.Errors);
        }

        [Fact]
        public async Task CreateUser_EmailEmpty_EmailFormatException()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("Juan", string.Empty, "Peru 2464", "+5491154762312", "Normal", "1234");

            Assert.False(result.IsSuccess);
            Assert.Contains("The email is required", result.Errors);
        }

        [Fact]
        public async Task CreateUser_UserTypeInIncorrect_UserTypeInIncorrectErrorException()
        {
            var userController = GetUserController();

            var result = await userController.CreateUser("Juan", "Juan@marmol.com", "Peru 2464", "+5491154762312", "serTypeInIncorrect", "1234");

            Assert.False(result.IsSuccess);
            Assert.Contains("The userType is incorrect", result.Errors);
        }

        #region "Private methods" 

        private static UsersController GetUserController()
        {
            var userRepository = new UsersService();
            var userCreationService = new UserCreationService(userRepository);
            var userValidationService = new UserValidationService();
            var userController = new UsersController(userCreationService, userValidationService);
            
            return userController;
        }

        #endregion
    }
}