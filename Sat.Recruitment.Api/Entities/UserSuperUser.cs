using System.Security.Policy;
using System;

namespace Sat.Recruitment.Api.Entities
{
    public class UserSuperUser : User
    {
        public UserSuperUser(User usersCreationParameters) : base(usersCreationParameters)
        {
            //Add gift to users with more than USD100.
            if (Money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = Money * percentage;
                Money = Money + gif;
            }
        }
    }
}
