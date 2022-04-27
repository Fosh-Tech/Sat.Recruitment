using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Users;

namespace Sat.Recruitment.Api.Applications
{
    public interface IUsersApplication
    {
        User CreateUsers(string name, string email, string address, string phone, UserTypes userType, decimal money);
    }
}
