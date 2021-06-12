namespace Sat.Recruitment.Api.Domain.Promotions
{
    internal sealed class ApplyPercentagePromotion : IPromotion
    {
        private decimal percentage;

        public ApplyPercentagePromotion(decimal percentage) => this.percentage = percentage;

        /// <inheritdoc />
        public User Apply(User user) => new User(user)
        {
            Money = this.ApplyPercentage(user.Money)
        };

        private decimal ApplyPercentage(decimal money) => money + money * this.percentage;
    }
}
