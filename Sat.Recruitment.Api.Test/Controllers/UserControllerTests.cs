using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.DTOs.User;
using Sat.Recruitment.Api.Exceptions;
using Sat.Recruitment.Api.Test.Fakes;
using Sat.Recruitment.Business.Concrete;
using System.Net;
using System.Xml.Linq;
using Xunit;

namespace Sat.Recruitment.Api.Test.Controllers
{
    public class UserControllerTests
    {
        private UserControllerFakes _fakes;
        public UserControllerTests()
        {
            _fakes = new UserControllerFakes();
        }

        [Fact]
        public async Task CreateUser_CorrectRequest_ReturnCreatedUser()
        {
            var userRequestFake = _fakes.GetCreateUserRequestFake();
            var userExpected = _fakes.GetUserFake();
            _fakes.UserService.Setup(f => f.CreateAsync(It.IsAny<UserBL>()))
                .ReturnsAsync(userExpected);

            var userCreate = await _fakes.UserController.CreateUser(userRequestFake);

            Assert.IsType<CreatedAtRouteResult>(userCreate.Result);
            var userReturned = Utils.GetObjectResultContent(userCreate);
            Assert.IsType<CreateUserResponse>(userReturned);
            Assert.Equal(userExpected.Id, userReturned.Id);
            Assert.Equal(userExpected.Name, userReturned.Name);
            Assert.Equal(userExpected.Email, userReturned.Email);
            Assert.Equal(userExpected.Address, userReturned.Address);
            Assert.Equal(userExpected.Phone, userReturned.Phone);
            Assert.Equal(userExpected.Type, userReturned.Type);
        }

        [Fact]
        public async Task CreateUser_EmailIncorrectFormat_ReturnEmailFormatException()
        {
            var userRequestFake = _fakes.GetCreateUserRequestFake();
            userRequestFake.Email = "formaterror";

            var exMsgExpected = $"The Email {userRequestFake.Email} is not in correct format.";
            var exCodeExpected = "EMAILFORMAT_ERROR";
            var exExpected = new EmailFormatException(exMsgExpected, exCodeExpected);

            var userExpected = _fakes.GetUserFake();
            _fakes.UserService.Setup(f => f.CreateAsync(It.IsAny<UserBL>()))
                .ReturnsAsync(userExpected);

            Func<Task> action = async () =>
            {
                await _fakes.UserController.CreateUser(userRequestFake);
            };

            var ex = await Assert.ThrowsAsync<EmailFormatException>(action);
            Assert.IsType<EmailFormatException>(ex);
            Assert.Equal(exMsgExpected, ex.Message);
            Assert.Equal(exCodeExpected, ex.Code);
        }

        [Fact]
        public async Task CreateUser_EmailNull_ReturnEmailFormatException()
        {
            var userRequestFake = _fakes.GetCreateUserRequestFake();
            userRequestFake.Email = null;

            var exMsgExpected = $"The Email field is required.";
            var exCodeExpected = "EMAILNULLOREMPTY_ERROR";
            var exExpected = new EmailFormatException(exMsgExpected, exCodeExpected);

            var userExpected = _fakes.GetUserFake();
            _fakes.UserService.Setup(f => f.CreateAsync(It.IsAny<UserBL>()))
                .ReturnsAsync(userExpected);

            Func<Task> action = async () =>
            {
                await _fakes.UserController.CreateUser(userRequestFake);
            };

            var ex = await Assert.ThrowsAsync<EmailFormatException>(action);
            Assert.IsType<EmailFormatException>(ex);
            Assert.Equal(exMsgExpected, ex.Message);
            Assert.Equal(exCodeExpected, ex.Code);
        }

        [Fact]
        public async Task CreateUser_EmailEmpty_ReturnEmailFormatException()
        {
            var userRequestFake = _fakes.GetCreateUserRequestFake();
            userRequestFake.Email = string.Empty;

            var exMsgExpected = $"The Email field is required.";
            var exCodeExpected = "EMAILNULLOREMPTY_ERROR";
            var exExpected = new EmailFormatException(exMsgExpected, exCodeExpected);

            var userExpected = _fakes.GetUserFake();
            _fakes.UserService.Setup(f => f.CreateAsync(It.IsAny<UserBL>()))
                .ReturnsAsync(userExpected);

            Func<Task> action = async () =>
            {
                await _fakes.UserController.CreateUser(userRequestFake);
            };

            var ex = await Assert.ThrowsAsync<EmailFormatException>(action);
            Assert.IsType<EmailFormatException>(ex);
            Assert.Equal(exMsgExpected, ex.Message);
            Assert.Equal(exCodeExpected, ex.Code);
        }

    }
}