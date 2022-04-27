using System.Collections.Generic;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Users;

namespace Sat.Recruitment.Api.Services
{
    public interface IUsersService
    {
        List<User> GetAllUsers();
    }
}
