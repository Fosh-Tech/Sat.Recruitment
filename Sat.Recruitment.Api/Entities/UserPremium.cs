using System.Security.Policy;

namespace Sat.Recruitment.Api.Entities
{
    public class UserPremium : User
    {
        public UserPremium(User usersCreationParameters) : base(usersCreationParameters)
        {
            //Add huge gift to users with more than USD100.
            if (Money > 100)
            {
                var gif = Money * 2;
                Money = Money + gif;
            }
        }
    }
}
