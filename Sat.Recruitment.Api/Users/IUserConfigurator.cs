using System;

namespace Sat.Recruitment.Api.Users
{
    public interface IUserConfigurator
    {
        UserTypes UserType { get; }
        void ConfigureMoney(User user);
    }
}
