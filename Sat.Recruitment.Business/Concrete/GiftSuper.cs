using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Business.Services;
using System;

namespace Sat.Recruitment.Business.Concrete
{
    public class GiftSuper : IGift
    {
        public void ApplyToUser(IUser user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gift = user.Money * percentage;
                user.Money += gift;
            }
        }
    }
}
