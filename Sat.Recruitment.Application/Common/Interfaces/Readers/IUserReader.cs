using Sat.Recruitment.Domain.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Common.Interfaces.Readers
{
    public interface IUserReader
    {
        Task<List<User>> ReadUsersFromFileAsync();
    }
}