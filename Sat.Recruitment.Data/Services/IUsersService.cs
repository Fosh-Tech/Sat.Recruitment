using System.Collections.Generic;
using Sat.Recruitment.Entities.Entities;

namespace Sat.Recruitment.Data.Services
{
    public interface IUsersService
    {
        List<User> GetAllUsers();
    }
}
