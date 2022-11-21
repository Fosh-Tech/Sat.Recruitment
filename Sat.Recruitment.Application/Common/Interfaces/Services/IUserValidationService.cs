using Sat.Recruitment.Application.Common.ViewModels;

namespace Sat.Recruitment.Application.Common.Interfaces.Services
{
    public interface IUserValidationService
    {
        Result ValidateUser(string name, string email, string address, string phone, string userType, string money);
    }
}