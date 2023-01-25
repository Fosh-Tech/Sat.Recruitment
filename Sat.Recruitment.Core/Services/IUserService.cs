using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Core.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Core.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserShared user);
    }
}
