using Sat.Recruitment.Entities.Entities;

namespace Sat.Recruitment.Application.Users
{
    public interface IUserValidator
    {
        void ValidateDuplicatedUsers(User user);
    }
}
