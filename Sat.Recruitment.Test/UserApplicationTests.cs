using System;
using System.Dynamic;

using Microsoft.AspNetCore.Mvc;

using Xunit;
using Sat.Recruitment.Api.Applications;
using Sat.Recruitment.Api.Users;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Exceptions;
using Moq;
using System.Collections.Generic;


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
            IUsersApplication _service = GetService();

            User user = _service.CreateUsers(string.Empty, "mail@mail.box", "address", "9876543", UserTypes.Normal, 123);

            Assert.NotNull(user);
            Assert.Null(user.Name);
            Assert.Null(user.Address);
            Assert.Null(user.Email);
            Assert.True(user.HasErrors);

            string errors = user.GetErrors();

            Assert.Equal(Constants.NAME_IS_MANDATORY, errors);

        }

        [Fact]
        public void CreateUser_WithWrongEmail_ThrowEMailException()
        {
            IUsersApplication _service = GetService();
            
            Assert.Throws<EMailException>(() => _service.CreateUsers("name", "mail", "address", "9876543", UserTypes.Normal, 123));
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
