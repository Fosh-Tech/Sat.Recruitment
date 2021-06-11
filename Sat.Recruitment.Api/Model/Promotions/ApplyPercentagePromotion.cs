namespace Sat.Recruitment.Api.Model.Promotions
{
    internal sealed class ApplyPercentagePromotion : IPromotion
    {
        private decimal percentage;

        public ApplyPercentagePromotion(decimal percentage) => this.percentage = percentage;

        /// <inheritdoc />
        public User Apply(User user) => new User
        {
            Address = user.Address,
            Email = user.Email,
            Money = this.ApplyPercentage(user.Money),
            Name = user.Name,
            Phone = user.Phone,
            UserType = user.UserType
        };

        private decimal ApplyPercentage(decimal money) => money + (money * this.percentage);
    }
}
