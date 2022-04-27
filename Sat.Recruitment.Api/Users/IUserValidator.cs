using System;
using Sat.Recruitment.Api.Common;

namespace Sat.Recruitment.Api.Users
{
    public interface IUserValidator
    {
        void ValidateDuplicatedUsers(User user);
    }
}
