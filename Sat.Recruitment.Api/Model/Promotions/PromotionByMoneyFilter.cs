using System;

namespace Sat.Recruitment.Api.Model.Promotions
{
    /// <summary>
    /// Applies another promotion only to users that matches a specified filter.
    /// </summary>
    internal sealed class PromotionByMoneyFilter : IPromotion
    {
        private IPromotion promotion;

        private Func<decimal, bool> shouldApply;

        /// <summary>
        /// Creates a new instance of <see cref="PromotionByMoneyFilter"/>.
        /// </summary>
        /// <param name="shouldApply">The filter used to matches users that should receive the promotion.</param>
        /// <param name="promotion">The promotion to be applied to users that matches the predicate.</param>
        public PromotionByMoneyFilter(Func<decimal, bool> shouldApply, IPromotion promotion)
        {
            this.promotion = promotion;
            this.shouldApply = shouldApply;
        }

        /// <inheritdoc />
        public User Apply(User user) => this.shouldApply(user.Money) ? this.promotion.Apply(user) : user;
    }
}
