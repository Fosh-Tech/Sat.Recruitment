using Sat.Recruitment.Dtos.Dtos;
using Sat.Recruitment.Entities.Entities;
using Sat.Recruitment.Entities.Enums;

namespace Sat.Recruitment.Application.Applications
{
    public interface IUsersApplication
    {
        UserDto CreateUsers(string name, string email, string address, string phone, string userType, string money);
    }
}
