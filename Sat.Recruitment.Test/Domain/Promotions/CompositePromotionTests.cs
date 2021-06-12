using FluentAssertions;

using NSubstitute;

using Sat.Recruitment.Api.Domain;
using Sat.Recruitment.Api.Domain.Promotions;

using Xunit;

namespace Sat.Recruitment.Test.Domain.Promotions
{
    public class CompositePromotionTests
    {
        [Fact]
        public void GivenAnyUser_WhenCompositeHasPromotions_PromotionInvoked()
        {
            var user = new User();
            var updatedUser = new User { Money = 55 };
            var promotion = Substitute.For<IPromotion>();
            promotion.Apply(Arg.Any<User>()).Returns(updatedUser);
            var sut = new CompositePromotion
            {
                promotion
            };

            User result = sut.Apply(user);

            promotion.Received().Apply(user);
            result.Should().BeSameAs(updatedUser);
        }

        [Fact]
        public void GivenAnyUser_WhenCompositeIsEmpty_SameUserReturned()
        {
            var user = new User();
            var sut = new CompositePromotion();

            User result = sut.Apply(user);

            result.Should().BeSameAs(user);
        }
    }
}
