using AutoFixture;

using FluentAssertions;

using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.Model.Promotions;

using Xunit;

namespace Sat.Recruitment.Test.Model.Promotions
{
    public class ApplyPercentagePromotionTests
    {
        private readonly Fixture fixture = new Fixture();

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0.5, 10, 15)]
        [InlineData(5, 10, 60)]
        public void GivenAnyUser_MultiplyByPercentage(decimal percentage, decimal money, decimal expected)
        {
            User user = this.fixture.Build<User>().With(x => x.Money, money).Create();
            var sut = new ApplyPercentagePromotion(percentage);

            User result = sut.Apply(user);

            result.Address.Should().Be(user.Address);
            result.Email.Should().Be(user.Email);
            result.Money.Should().Be(expected);
            result.Name.Should().Be(user.Name);
            result.Phone.Should().Be(user.Phone);
            result.UserType.Should().Be(user.UserType);
        }
    }
}
