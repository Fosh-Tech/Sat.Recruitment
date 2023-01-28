using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.DTOs.User;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Data.Context;
using Sat.Recruitment.Service.Services;

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

        public CreateUserRequest GetCreateUserRequestFake()
        {
            return new CreateUserRequest()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                Type = "Normal",
                Money = 124
            };
        }

        public User GetUserFake()
        {
            return new User()
            {
                Id = 1,
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                Type = "Normal",
                Money = 124
            };
        }

        public UserBL GetUserBLFake()
        {
            return new UserBL()
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                Type = "Normal",
                Money = 124
            };
        }
    }
}
