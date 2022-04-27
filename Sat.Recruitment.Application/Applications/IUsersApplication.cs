using Sat.Recruitment.Entities.Entities;
using Sat.Recruitment.Entities.Enums;

namespace Sat.Recruitment.Application.Applications
{
    public interface IUsersApplication
    {
        User CreateUsers(string name, string email, string address, string phone, UserTypes userType, decimal money);
    }
}
