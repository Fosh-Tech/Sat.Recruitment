using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Data.Context;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Services
{
    public interface IUserService
    {
        Task<User> CreateAsync(UserBL user);
    }
}
