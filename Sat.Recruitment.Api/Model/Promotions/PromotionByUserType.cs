namespace Sat.Recruitment.Api.Model.Promotions
{
    /// <summary>
    /// Applies a promotion only to users of a specific type.
    /// </summary>
    /// <remarks>
    /// This rule acts as a decorator, so the discount to be applied is defined elsewhere.
    /// The type comparison (because types should be normalized on its own type) is case-insensitive.
    /// </remarks>
    internal sealed class PromotionByUserType : IPromotion
    {
        private readonly IPromotion discount;

        private readonly string userType;

        public PromotionByUserType(string userType, IPromotion discount)
        {
            this.discount = discount;
            this.userType = userType;
        }

        /// <inheritdoc />
        public User Apply(User user)
        {
            if (user.UserType?.Equals(this.userType) == true)
            {
                return this.discount.Apply(user);
            }

            return user;
        }
    }
}
