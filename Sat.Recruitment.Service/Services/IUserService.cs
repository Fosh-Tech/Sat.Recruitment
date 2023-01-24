using Sat.Recruitment.Core.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserShared user);
    }
}
