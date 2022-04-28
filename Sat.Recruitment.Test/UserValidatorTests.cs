using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using Sat.Recruitment.Data.Services;
using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Application.Users;
using Sat.Recruitment.Entities.Entities;
using Sat.Recruitment.Dtos.Dtos;
using Sat.Recruitment.Dtos.Enums;


namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserValidatorTests
    {
        private Mock<IUsersService> _usersService;

        [Fact]
        public void ConfigureMoney_WithNullUser_ThrowArgumentNullException()
        {
            IUserValidator _service = GetService();
            
            Assert.Throws<ArgumentNullException>(() => _service.ValidateDuplicatedUsers(null));
        }

        [Fact]
        public void ConfigureMoney_WithNoStoredUsers_NoDuplicatedUser()
        {
            IUserValidator service = GetService();

            UserDto user = new UserDto("name", "mail@mail.box", "address", "9876543", "Normal", "123");

            _usersService.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            service.ValidateDuplicatedUsers(user);
        }

        [Fact]
        public void ConfigureMoney_WithNoDuplicatedUsers_NoDuplicatedUser()
        {
            IUserValidator service = GetService();

            UserDto user = new UserDto("name", "mail@mail.box", "address", "9876543", "Normal", "123");
            User storedUser = new User("name01", "mail01@mail.box", "address01", "9876544", "Normal", "123");

            _usersService.Setup(x => x.GetAllUsers()).Returns(new List<User>() { storedUser });

            service.ValidateDuplicatedUsers(user);

            _usersService.Verify(x => x.GetAllUsers(), Times.Once);
        }

        [Fact]
        public void ConfigureMoney_WithDuplicatedUsers_ThrowDuplicatedUserException()
        {
            IUserValidator service = GetService();

            User storedUser = new User("name", "mail@mail.box", "address", "9876543", "Normal", "123");
            UserDto user = new UserDto("name", "mail@mail.box", "address", "9876543", "Normal", "123");

            _usersService.Setup(x => x.GetAllUsers()).Returns(new List<User>() { storedUser });

            Assert.Throws<DuplicatedUserException>(() => service.ValidateDuplicatedUsers(user));

            _usersService.Verify(x => x.GetAllUsers(), Times.Once);
        }

        private IUserValidator GetService()
        {
            _usersService = new Mock<IUsersService>();

            return new UserValidator(_usersService.Object);  
        }



    }
}
