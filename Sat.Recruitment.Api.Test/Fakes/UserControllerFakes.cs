using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Api.Test.Fakes
{
    public class UserControllerFakes
    {
        public UserController UserController { get; set; }
        public Mock<IUserService> UserService { get; set; }

        public UserControllerFakes()
        {
            UserService = new Mock<IUserService>();
            UserController = new UserController(UserService.Object);
        }
    }
}
