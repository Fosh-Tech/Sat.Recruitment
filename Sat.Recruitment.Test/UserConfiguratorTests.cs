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
        [InlineData(120, 134.40)]
        [InlineData(100, 100)]
        [InlineData(80, 144)]
        public void ConfigureMoney_WithInformedUser_SetExpectedValue(decimal money, decimal expectedMoney)
        {
            IUserConfigurator service = GetService();

            User user = new User("name", "mail@mail.box", "address", "9876543", UserTypes.Normal, money);

            service.ConfigureMoney(user);

            Assert.Equal(expectedMoney, user.Money);
        }

        private IUserConfigurator GetService()
        {

            return new NormalConfigurator();  
        }



    }
}