
using Moq;
using Sat.Recruitment.Api.Applications;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Exceptions;
using Sat.Recruitment.Api.Users;
using System.Collections.Generic;
using Xunit;


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

            User user = service.CreateUsers(string.Empty, "mail@mail.box", "address", "9876543", UserTypes.Normal, 123);

            Assert.NotNull(user);
            Assert.Null(user.Name);
            Assert.Null(user.Address);
            Assert.Null(user.Email);
            Assert.Null(user.Phone);
            Assert.True(user.HasErrors);

            string errors = user.GetErrors();

            Assert.Equal(Constants.NAME_IS_MANDATORY, errors);

        }

        [Fact]
        public void CreateUser_WithWrongEmail_ThrowEMailException()
        {
            IUsersApplication service = GetService();
            
            Assert.Throws<EMailException>(() => service.CreateUsers("name", "mail", "address", "9876543", UserTypes.Normal, 123));
        }


        [Fact]
        public void CreateUser_WithNoValidator_ThrowIocException()
        {
            IUsersApplication service = GetService();

            _userConfigurator.Setup(x => x.UserType).Returns(UserTypes.SuperUser);

            Assert.Throws<IocException>(() => service.CreateUsers("name", "mail@mail.box", "address", "9876543", UserTypes.Normal, 123));
        }

        [Fact]
        public void CreateUser_WithInformedParameter_ReturnUserCreated()
        {
            IUsersApplication service = GetService();

            User user = service.CreateUsers("name", "mail@mail.box", "address", "9876543", UserTypes.Normal, 123);

            _userConfigurator.Setup(x => x.UserType).Returns(UserTypes.Normal);

            Assert.NotNull(user);
            Assert.Equal("name", user.Name);
            Assert.Equal("address", user.Address);
            Assert.Equal("mail@mail.box", user.Email);
            Assert.Equal("9876543", user.Phone);
            Assert.Equal(UserTypes.Normal, user.UserType);
            Assert.Equal(123, user.Money);
            Assert.False(user.HasErrors);

            _userConfigurator.Verify(x => x.ConfigureMoney(It.IsAny<User>()), Times.Once);
            _userValidator.Verify(x => x.ValidateDuplicatedUsers(It.IsAny<User>()), Times.Once);

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
