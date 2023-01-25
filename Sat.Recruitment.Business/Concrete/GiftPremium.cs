using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Business.Services;

namespace Sat.Recruitment.Business.Concrete
{
    public class GiftPremium : IGift
    {
        public void ApplyToUser(IUser user)
        {
            if (user.Money > 100)
            {
                var gif = user.Money * 2;
                user.Money += gif;
            }
        }
    }
}
