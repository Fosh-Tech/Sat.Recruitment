using Sat.Recruitment.Api.Model.Promotions;

namespace Sat.Recruitment.Api.Model.Validators
{
    internal static class Defaults
    {
        public static IValidationRule Validator() => new CompositeValidationRule
        {
            new StringNotNullValidationRule(x => x.Name, "The name is required"),
            new StringNotNullValidationRule(x => x.Email, "The email is required"),
            new StringNotNullValidationRule(x => x.Address, "The address is required"),
            new StringNotNullValidationRule(x => x.Phone, "The phone is required")
        };

        public static IPromotion Promotion() => new CompositePromotion
        {
            NormalUserPromotion(),
            NormalUserPromotion(),
            PremiumUserPromotion()
        };

        private static IPromotion NormalUserPromotion() =>
            new PromotionByUserType(
                "Normal",
                new CompositePromotion
                {
                    new PromotionByMoneyFilter(x => x > 100, new ApplyPercentagePromotion(0.12m)),
                    new PromotionByMoneyFilter(x => x < 100, new PromotionByMoneyFilter(x => x > 10, new ApplyPercentagePromotion(0.8m)))
                });

        private static IPromotion SuperUserPromotion() =>
            new PromotionByUserType(
                "SuperUser",
                new PromotionByMoneyFilter(x => x > 100, new ApplyPercentagePromotion(0.20m)));

        private static IPromotion PremiumUserPromotion() =>
            new PromotionByUserType(
                "Premium",
                new PromotionByMoneyFilter(x => x > 100, new ApplyPercentagePromotion(2m)));
    }
}
