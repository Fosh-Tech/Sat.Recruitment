﻿using System;

namespace Sat.Recruitment.Api.Users
{
    public class SuperUserConfigurator : IUserConfigurator
    {
        UserTypes IUserConfigurator.UserType => UserTypes.SuperUser;

        void IUserConfigurator.ConfigureMoney(User user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));

            decimal percentage = Convert.ToDecimal(0.20);
            decimal gif = user.Money * percentage;

            user.Money += gif;
        }
    }
}
