using Sat.Recruitment.Application.Common.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Common.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserViewModel>> GetUsersAsync();
    }
}