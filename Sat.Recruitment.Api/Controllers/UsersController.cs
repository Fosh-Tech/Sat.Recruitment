using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Sat.Recruitment.Application.Applications;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Dtos.Exceptions;
using Sat.Recruitment.Entities.Entities;
using Sat.Recruitment.Entities.Enums;
using Unity;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly IUsersApplication _usersApplication;

        public UsersController()
        {
            _usersApplication = IocContainer.Resolve<IUsersApplication>();
        }

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            decimal userMoney;
            
            if (!decimal.TryParse(money, out decimal parsedMoney))
            {
                userMoney = 0;
            }

            if (!Enum.TryParse<UserTypes>(userType, out UserTypes type))
            {
                throw new UserTypeException();
            }

            Result result;

            try
            {
                User newUser = _usersApplication.CreateUsers(name, email, address, phone, type, parsedMoney);

                result = new Result(true, Constants.CREATED_USER);
            }
            catch (DuplicatedUserException duplicatedUserException)
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
