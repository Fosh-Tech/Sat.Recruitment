using NSubstitute;

using Sat.Recruitment.Api.Model;
using Sat.Recruitment.Api.Model.Promotions;

using Xunit;

namespace Sat.Recruitment.Test.Model.Promotions
{
    public class PromotionByMoneyFilterTests
    {
        [Fact]
        public void GivenAnyUser_WhenMoneyMatchesFilter_PromotionApplied()
        {
            var user = new User();
            var promotion = Substitute.For<IPromotion>();
            var sut = new PromotionByMoneyFilter(_ => true, promotion);

            sut.Apply(user);

            promotion.Received().Apply(user);
        }

        [Fact]
        public void GivenAnyUser_WhenMoneyMatchesFilter_PromotionNotApplied()
        {
            var user = new User();
            var promotion = Substitute.For<IPromotion>();
            var sut = new PromotionByMoneyFilter(_ => false, promotion);

            sut.Apply(user);

            promotion.DidNotReceive().Apply(Arg.Any<User>());
        }
    }
}
