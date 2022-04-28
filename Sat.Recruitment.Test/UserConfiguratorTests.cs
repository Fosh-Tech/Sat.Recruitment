using Moq;
using Sat.Recruitment.Api.Common;
using System.Collections.Generic;
using System;
using Xunit;
using Sat.Recruitment.Application.Users;
using Sat.Recruitment.Application.Applications;
using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Dtos.Common;
using Sat.Recruitment.Dtos.Enums;
using Sat.Recruitment.Dtos.Dtos;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class NormalConfiguratorTests
    {
        private IUserConfigurator _userConfigurator;

        [Fact]
        public void ConfigureMoney_WithNullUser_ThrowArgumentNullException()
        {
            IUserConfigurator _service = GetService();
            
            Assert.Throws<ArgumentNullException>(() => _service.ConfigureMoney(null));
        }

        [Theory]
        [InlineData("120", 134.40)]
        [InlineData("100", 100)]
        [InlineData("80", 144)]
        public void ConfigureMoney_WithInformedUser_SetExpectedValue(string money, decimal expectedMoney)
        {
            IUserConfigurator service = GetService();

            UserDto user = new UserDto("name", "mail@mail.box", "address", "9876543", "Normal", money);

            service.ConfigureMoney(user);

            Assert.Equal(expectedMoney, user.Money);
        }

        private IUserConfigurator GetService()
        {

            return new NormalConfigurator();  
        }

    }
}
