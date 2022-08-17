using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Entities;

using Xunit;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UnitTest1
    {
        [Fact]
        public void CheckRightUserCreation()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Mike", "mike@gmail.com", "Av. Juan G", "+349 1122354215", "Normal", "124").Result;


            Assert.True(result.IsSuccess);
            Assert.Equal("User Created", result.Errors);
        }

        [Fact]
        public void CheckDuplicatedUserByEmail()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("RepeatedEmail", "Agustina@gmail.com", "RepeatedEmail", "+000 1122354215", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void CheckDuplicatedUserByPhone()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("RepeatedPhone", "RepeatedPhone@gmail.com", "RepeatedPhone", "+534645213542", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void CheckDuplicatedUserByNameAndAddress()
        {
            var userController = new UsersController();

            var result = userController.CreateUser("Agustina", "RepeatedNameAndAddress@gmail.com", "Garay y Otra Calle", "+000 1122354215", "Normal", "124").Result;


            Assert.False(result.IsSuccess);
            Assert.Equal("The user is duplicated", result.Errors);
        }

        [Fact]
        public void CheckUserFieldsValidation()
        {
            var userController = new UsersController();

            var result = userController.CreateUser(null, null, null, null, "Normal", "NonParseableMoney").Result;


            Assert.False(result.IsSuccess);
            Assert.Contains("The name is required", result.Errors);
            Assert.Contains("The email is required", result.Errors);
            Assert.Contains("The address is required", result.Errors);
            Assert.Contains("The phone is required", result.Errors);
            Assert.Contains("The money value is not parseable", result.Errors);
        }

        //TODO Users persistance must be implemented
        //public void CheckUserNormalizedEmail()
        //{
        //}

        [Fact]
        public void CheckGiftsInUserCreation()
        {
            var userParams = new UsersCreationParameters()
            {
                UserType = "Normal",
                Money = 10
            };
            User normalUser10 = UsersFactory.newUser(userParams);

            userParams.Money = 50;
            User normalUser50 = UsersFactory.newUser(userParams);

            userParams.Money = 100;
            User normalUser100 = UsersFactory.newUser(userParams);

            userParams.Money = 200;
            User normalUser200 = UsersFactory.newUser(userParams);

            userParams.UserType = "SuperUser";
            userParams.Money = 100;
            User superUser100 = UsersFactory.newUser(userParams);

            userParams.Money = 200;
            User superUser200 = UsersFactory.newUser(userParams);

            userParams.UserType = "Premium";
            userParams.Money = 100;
            User premiumUser100 = UsersFactory.newUser(userParams);

            userParams.Money = 150;
            User premiumUser150 = UsersFactory.newUser(userParams);


            Assert.Equal(10,  normalUser10.Money);
            Assert.Equal(90,  normalUser50.Money); //TODO make sure this is right. It seems it should be 54.
            Assert.Equal(100, normalUser100.Money);
            Assert.Equal(224, normalUser200.Money);
            Assert.Equal(100, superUser100.Money);
            Assert.Equal(240, superUser200.Money);
            Assert.Equal(100, premiumUser100.Money);
            Assert.Equal(450, premiumUser150.Money);
        }
    }
}
