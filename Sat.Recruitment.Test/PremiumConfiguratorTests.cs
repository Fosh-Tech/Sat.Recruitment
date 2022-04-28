using System;
using Xunit;
using Sat.Recruitment.Application.Users;
using Sat.Recruitment.Dtos.Dtos;

namespace Sat.Recruitment.Test
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class PremiumConfiguratorTests
    {
        [Fact]
        public void ConfigureMoney_WithNullUser_ThrowArgumentNullException()
        {
            IUserConfigurator _service = GetService();
            
            Assert.Throws<ArgumentNullException>(() => _service.ConfigureMoney(null));
        }

        [Theory]
        [InlineData("100", 300)]
        [InlineData("50", 150)]
        public void ConfigureMoney_WithInformedUser_SetExpectedValue(string money, decimal expectedMoney)
        {
            IUserConfigurator service = GetService();

            UserDto user = new UserDto("name", "mail@mail.box", "address", "9876543", "Normal", money);

            service.ConfigureMoney(user);

            Assert.Equal(expectedMoney, user.Money);
        }

        private IUserConfigurator GetService()
        {

            return new PremiumConfigurator();  
        }



    }
}
