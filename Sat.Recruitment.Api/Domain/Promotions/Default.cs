namespace Sat.Recruitment.Api.Domain.Promotions
{
    internal static class Default
    {
        public static IPromotion Create() => new CompositePromotion
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
