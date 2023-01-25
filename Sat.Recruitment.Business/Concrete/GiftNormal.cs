using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Business.Services;
using System;

namespace Sat.Recruitment.Business.Concrete
{
    public class GiftNormal : IGift
    {
        public void ApplyToUser(IUser user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                var gif = user.Money * percentage;
                user.Money += gif;
            }

            if (user.Money < 100 && user.Money > 10)
            {
                var percentage = Convert.ToDecimal(0.8);
                var gif = user.Money * percentage;
                user.Money += gif;
            }
        }
    }
}
