using Sat.Recruitment.Dtos.Dtos;
using Sat.Recruitment.Entities.Entities;

namespace Sat.Recruitment.Application.Applications
{
    public interface IUsersApplication
    {
        UserDto CreateUsers(string name, string email, string address, string phone, string userType, string money);
    }
}
