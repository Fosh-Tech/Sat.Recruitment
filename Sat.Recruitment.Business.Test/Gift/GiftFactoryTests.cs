using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Test.Fakes;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Business.Test.Gift
{
    public class GiftFactoryTests
    {
        private readonly GiftFactoryFakes _fakes;

        public GiftFactoryTests()
        {
            _fakes = new GiftFactoryFakes();
        }

        #region GiftNormal
        [Fact]
        public async Task GiftApply_UserNormalWithMoneyGreaterThan100_ReturnMoneyPlus12Percent()
        {
            var userNormal = _fakes.GetUserNormal();
            userNormal.Money = 200;
            var percentage = Convert.ToDecimal(0.12);
            var gift = userNormal.Money * percentage;
            var moneyExpected = userNormal.Money + gift;
            var giftNormal = new GiftNormal();
            
            giftNormal.ApplyToUser(userNormal);

            Assert.Equal(moneyExpected, userNormal.Money);
        }

        [Fact]
        public async Task GiftApply_UserNormalWithMoneyBetween10And100_ReturnMoneyPlus8Percent()
        {
            var userNormal = _fakes.GetUserNormal();
            userNormal.Money = 50;
            var percentage = Convert.ToDecimal(0.8);
            var gift = userNormal.Money * percentage;
            var moneyExpected = userNormal.Money + gift;
            var giftNormal = new GiftNormal();

            giftNormal.ApplyToUser(userNormal);

            Assert.Equal(moneyExpected, userNormal.Money);
        }

        [Fact]
        public async Task GiftApply_UserNormalWithMoneyLessThan10_ReturnInitialMoney()
        {
            var userNormal = _fakes.GetUserNormal();
            userNormal.Money = 8;
            var moneyExpected = 8;
            var giftNormal = new GiftNormal();

            giftNormal.ApplyToUser(userNormal);

            Assert.Equal(moneyExpected, userNormal.Money);
        }

        [Fact]
        public async Task GiftApply_UserNormalWithMoneyEqual100_ReturnInitialMoney()
        {
            var userNormal = _fakes.GetUserNormal();
            userNormal.Money = 100;
            var moneyExpected = 100;
            var giftNormal = new GiftNormal();

            giftNormal.ApplyToUser(userNormal);

            Assert.Equal(moneyExpected, userNormal.Money);
        }

        [Fact]
        public async Task GiftApply_UserNormalWithMoneyEqual10_ReturnInitialMoney()
        {
            var userNormal = _fakes.GetUserNormal();
            userNormal.Money = 10;
            var moneyExpected = 10;
            var giftNormal = new GiftNormal();

            giftNormal.ApplyToUser(userNormal);

            Assert.Equal(moneyExpected, userNormal.Money);
        }
        #endregion

        #region GiftPremium
        [Fact]
        public async Task GiftApply_UserPremiumWithMoneyGreaterThan100_ReturnMoneyPlus200Percent()
        {
            var userPremium = _fakes.GetUserPremium();
            userPremium.Money = 101;
            var gift = userPremium.Money * 2;
            var moneyExpected = userPremium.Money + gift;
            var giftPremium = new GiftPremium();

            giftPremium.ApplyToUser(userPremium);

            Assert.Equal(moneyExpected, userPremium.Money);
        }

        [Fact]
        public async Task GiftApply_UserPremiumWithMoneyLessThan100_ReturnInitialMoney()
        {
            var userPremium = _fakes.GetUserPremium();
            userPremium.Money = 90;
            var moneyExpected = 90;
            var giftPremium = new GiftPremium();

            giftPremium.ApplyToUser(userPremium);

            Assert.Equal(moneyExpected, userPremium.Money);
        }

        [Fact]
        public async Task GiftApply_UserPremiumWithMoneyEqual100_ReturnInitialMoney()
        {
            var userPremium = _fakes.GetUserPremium();
            userPremium.Money = 100;
            var moneyExpected = 100;
            var giftPremium = new GiftPremium();

            giftPremium.ApplyToUser(userPremium);

            Assert.Equal(moneyExpected, userPremium.Money);
        }
        #endregion

        #region GiftSuper
        [Fact]
        public async Task GiftApply_UserSuperWithMoneyGreaterThan100_ReturnMoneyPlus20Percent()
        {
            var userSuper = _fakes.GetUserSuper();
            userSuper.Money = 500;
            var percentage = Convert.ToDecimal(0.20);
            var gift = userSuper.Money * percentage;
            var moneyExpected = userSuper.Money + gift;
            var giftSuper = new GiftSuper();

            giftSuper.ApplyToUser(userSuper);

            Assert.Equal(moneyExpected, userSuper.Money);
        }

        [Fact]
        public async Task GiftApply_UserSupermWithMoneyLessThan100_ReturnInitialMoney()
        {
            var userSuper = _fakes.GetUserSuper();
            userSuper.Money = 50;
            var moneyExpected = 50;
            var giftSuper = new GiftSuper();

            giftSuper.ApplyToUser(userSuper);

            Assert.Equal(moneyExpected, userSuper.Money);
        }

        [Fact]
        public async Task GiftApply_UserSuperWithMoneyEqual100_ReturnInitialMoney()
        {
            var userSuper = _fakes.GetUserSuper();
            userSuper.Money = 5;
            var moneyExpected = 5;
            var giftSuper = new GiftSuper();

            giftSuper.ApplyToUser(userSuper);

            Assert.Equal(moneyExpected, userSuper.Money);
        }
        #endregion
    }
}