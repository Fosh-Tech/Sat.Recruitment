using System.IO;
using AutoMapper;

using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Infrastructure.Persistence.Mapper;
using Sat.Recruitment.Infrastructure.Persistence.Readers;
using Sat.Recruitment.Infrastructure.Persistence.Repositories;
using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTestShould
    {
        [Fact]
        public void CreateNewUser()
        {
            var userController = CreateUserController();

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void Error_When_DuplicatedEmail()
        {
            var userController = CreateUserController();

            var result = userController.CreateUser("Agustina", "Agustina@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Contains("The user is duplicated", result.Errors);
        }

        [Fact]
        public void Error_When_DuplicatedPhone()
        {
            var userController = CreateUserController();

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+534645213542", "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Contains("The user is duplicated", result.Errors);
        }


        [Fact]
        public void Error_When_DuplicatedNameAndAddress()
        {
            var userController = CreateUserController();

            var result = userController.CreateUser("Agustina", "mike@gmail.com", "Garay y Otra Calle", "+349 1122354215", "Normal", "124").Result;

            Assert.False(result.IsSuccess);
            Assert.Contains("The user is duplicated", result.Errors);
        }

        [Fact]
        public void Error_When_ParameterValidationFails()
        {
            var userController = CreateUserController();

            var result = userController.CreateUser(null, null, null, null, null, null).Result;

            Assert.False(result.IsSuccess);
            Assert.Contains("The name is required", result.Errors);
            Assert.Contains("The email is required", result.Errors);
            Assert.Contains("The address is required", result.Errors);
            Assert.Contains("The phone is required", result.Errors);
            Assert.Contains("The userType is required and has to be one of the following: Normal, SuperUser, Premium", result.Errors);
            Assert.Contains("The money parameter should be a number", result.Errors);
        }

        private static UserController CreateUserController()
        {
            var userReader = new UserReader(Directory.GetCurrentDirectory() + "/Files/Users.txt");
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GeneralProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var userRepository = new UserRepository(userReader, mapper);
            var userCreationService = new UserCreationService(userRepository);
            var userValidationService = new UserValidationService();
            var userController = new UserController(userCreationService, userValidationService);
            return userController;
        }
    }
}
