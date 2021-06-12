using FluentAssertions;

using NSubstitute;

using Sat.Recruitment.Api.Domain;
using Sat.Recruitment.Api.Domain.Promotions;

using Xunit;

namespace Sat.Recruitment.Test.Domain.Promotions
{
    public class PromotionToUserTypeTests
    {
        [Fact]
        public void GivenAnyUser_WhenUserTypeMatches_InnerPromotionIsApplied()
        {
            var user = new User { UserType = "SAME" };
            var expectedUser = new User();
            var promotion = Substitute.For<IPromotion>();
            promotion.Apply(user).Returns(expectedUser);
            var sut = new PromotionByUserType(user.UserType, promotion);

            User receivedUser = sut.Apply(user);

            promotion.Received().Apply(user);
            receivedUser.Should().BeSameAs(expectedUser);
        }

        [Theory]
        [InlineData("OTHER")]
        [InlineData("")]
        [InlineData(null)]
        public void GivenAnyUser_WhenUserDoesNotMatch_InnerPromotionNotApplied(string userType)
        {
            var user = new User { UserType = userType };
            var promotion = Substitute.For<IPromotion>();
            promotion.Apply(user).Returns(new User());
            var sut = new PromotionByUserType("DIFFERENT", promotion);

            User receivedUser = sut.Apply(user);

            promotion.DidNotReceive().Apply(Arg.Any<User>());
            receivedUser.Should().BeSameAs(user);
        }
    }
}
