using System;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Sat.Recruitment.Api.Applications;
using Sat.Recruitment.Api.Users;
using Sat.Recruitment.Api.Services;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Exceptions;
using Moq;
using System.Collections.Generic;


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

            User user = new User("name", "mail@mail.box", "address", "9876543", UserTypes.Normal, 123);

            _usersService.Setup(x => x.GetAllUsers()).Returns(new List<User>());

            service.ValidateDuplicatedUsers(user);
        }

        [Fact]
        public void ConfigureMoney_WithNoDuplicatedUsers_NoDuplicatedUser()
        {
            IUserValidator service = GetService();

            User user = new User("name", "mail@mail.box", "address", "9876543", UserTypes.Normal, 123);
            User storedUser = new User("name01", "mail01@mail.box", "address01", "9876544", UserTypes.Normal, 123);

            _usersService.Setup(x => x.GetAllUsers()).Returns(new List<User>() { storedUser });

            service.ValidateDuplicatedUsers(user);

            _usersService.Verify(x => x.GetAllUsers(), Times.Once);
        }

        [Fact]
        public void ConfigureMoney_WithDuplicatedUsers_ThrowDuplicatedUserException()
        {
            IUserValidator service = GetService();

            User user = new User("name", "mail@mail.box", "address", "9876543", UserTypes.Normal, 123);

            _usersService.Setup(x => x.GetAllUsers()).Returns(new List<User>() { user });

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
