using System;
using Sat.Recruitment.Entities.Entities;
using Sat.Recruitment.Entities.Enums;

namespace Sat.Recruitment.Application.Users
{
    public interface IUserConfigurator
    {
        UserTypes UserType { get; }
        void ConfigureMoney(User user);
    }
}
