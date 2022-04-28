
using Moq;
using Sat.Recruitment.Api.Common;
using System.Collections.Generic;
using Xunit;
using Sat.Recruitment.Application.Users;
using Sat.Recruitment.Application.Applications;
using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Dtos.Common;
using Sat.Recruitment.Dtos.Enums;
using Sat.Recruitment.Dtos.Dtos;
using Sat.Recruitment.Dtos.Exceptions;


namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserApplicationTests
    {
        private Mock<IUserValidator> _userValidator = new Mock<IUserValidator>();
        private Mock<IUserConfigurator> _userConfigurator = new Mock<IUserConfigurator>();
        private List<IUserConfigurator> _userConfigurators;

        [Fact]
        public void CreateUser_WithWrongParameter_NoUserCreated()
        {
            IUsersApplication service = GetService();

            UserDto user = service.CreateUsers(string.Empty, "mail@mail.box", "address", "9876543", "Normal", "123");

            Assert.NotNull(user);
            Assert.Null(user.Name);
            Assert.Null(user.Address);
            Assert.Null(user.Email);
            Assert.Null(user.Phone);
            Assert.True(user.HasErrors);

            string errors = user.GetErrors();

            Assert.Equal(Dtos.Common.Constants.NAME_IS_MANDATORY, errors);

        }

        [Fact]
        public void CreateUser_WithWrongEmail_ThrowEMailException()
        {
            IUsersApplication service = GetService();
            
            Assert.Throws<EMailException>(() => service.CreateUsers("name", "mail", "address", "9876543", "Normal", "123"));
        }


        [Fact]
        public void CreateUser_WithNoValidator_ThrowIocException()
        {
            IUsersApplication service = GetService();

            _userConfigurator.Setup(x => x.UserType).Returns(UserTypes.SuperUser);

            Assert.Throws<IocException>(() => service.CreateUsers("name", "mail@mail.box", "address", "9876543", "Normal", "123"));
        }

        [Fact]
        public void CreateUser_WithInformedParameter_ReturnUserCreated()
        {
            IUsersApplication service = GetService();

            UserDto user = service.CreateUsers("name", "mail@mail.box", "address", "9876543", "Normal", "123");

            _userConfigurator.Setup(x => x.UserType).Returns(UserTypes.Normal);

            Assert.NotNull(user);
            Assert.Equal("name", user.Name);
            Assert.Equal("address", user.Address);
            Assert.Equal("mail@mail.box", user.Email);
            Assert.Equal("9876543", user.Phone);
            Assert.Equal(UserTypes.Normal, user.UserType);
            Assert.Equal(123, user.Money);
            Assert.False(user.HasErrors);

            _userConfigurator.Verify(x => x.ConfigureMoney(It.IsAny<UserDto>()), Times.Once);
            _userValidator.Verify(x => x.ValidateDuplicatedUsers(It.IsAny<UserDto>()), Times.Once);

        }

        private IUsersApplication GetService()
        {
            _userValidator = new Mock<IUserValidator>();
            _userConfigurator = new Mock<IUserConfigurator>();

            _userConfigurators = new List<IUserConfigurator>()
            {
                _userConfigurator.Object
            };

            return new UsersApplication(_userValidator.Object, _userConfigurators);  
        }



    }
}
