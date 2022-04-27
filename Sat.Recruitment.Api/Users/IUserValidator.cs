using System;

namespace Sat.Recruitment.Api.Users
{
    public interface IUserValidator
    {
        void Validate(User user);
    }
}
