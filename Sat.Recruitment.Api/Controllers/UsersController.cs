using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Sat.Recruitment.Application.Applications;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Dtos.Dtos;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUsersApplication _usersApplication;

        public UsersController(IUsersApplication usersApplication)
        {
            _usersApplication = usersApplication ?? throw new ArgumentNullException(nameof(usersApplication));
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(ApiUser user)
        {

            Result result;

            try
            {
                UserDto newUser = _usersApplication.CreateUsers(user.Name, user.Email, user.Address, user.Phone, user.UserType, user.Money);

                result = new Result(true, Constants.CREATED_USER);
            }
            catch (DuplicatedUserException)
            {
                result = new Result(true, Constants.DUPLICATED_USER);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return result;
        }

    }
}
