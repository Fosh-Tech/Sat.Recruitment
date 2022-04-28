using System;
using Sat.Recruitment.Dtos.Dtos;
using Sat.Recruitment.Dtos.Enums;

namespace Sat.Recruitment.Application.Users
{
    public interface IUserConfigurator
    {
        UserTypes UserType { get; }
        void ConfigureMoney(UserDto user);
    }
}
