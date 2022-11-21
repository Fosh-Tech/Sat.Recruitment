using Sat.Recruitment.Application.Common.ViewModels;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Common.Interfaces.Services
{
    public interface IUserCreationService
    {
        Task<Result> CreateUserAsync(string name, string email, string address, string phone, string userType, string money);
    }
}