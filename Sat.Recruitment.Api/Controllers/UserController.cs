using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Application.Common.Interfaces.Services;
using Sat.Recruitment.Application.Common.ViewModels;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UserController : ControllerBase
    {
        private readonly IUserCreationService userCreationService;
        private readonly IUserValidationService userValidationService;

        public UserController(IUserCreationService userCreationService, IUserValidationService userValidationService)
        {
            this.userCreationService = userCreationService;
            this.userValidationService = userValidationService;
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            var result = this.userValidationService.ValidateUser(name, email, address, phone, userType, money);

            if (!result.IsSuccess)
            {
                return result;
            }

            return await this.userCreationService.CreateUserAsync(name, email, address, phone, userType, money);
        }
    }
}