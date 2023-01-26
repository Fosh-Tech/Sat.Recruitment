using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Data.Context;
using Sat.Recruitment.Service.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Sat.Recruitment.Test.Users
{
    public class UserServiceTests
    {
        private readonly UserServiceFakes _fakes;

        public UserServiceTests()
        {
            _fakes = new UserServiceFakes();
        }

        [Fact]
        public async Task CreateUser_UserNull_ThrowException()
        {
            UserShared userFake = null;
            var exMsgExpected = "Value cannot be null. (Parameter 'UserShared')";

            Func<Task> action = async () =>
            {
                await _fakes.UserService.CreateAsync(userFake);
            };

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(action);

            Assert.IsType<ArgumentNullException>(ex);
            Assert.Equal(exMsgExpected, ex.Message);
        }

        [Fact]
        public async Task CreateUser_UserEmailNullOrEmpty_ThrowException()
        {
            UserShared userFake = new UserShared();
            var exMsgExpected = "Value cannot be null. (Parameter 'UserShared -> Email')";

            Func<Task> action = async () =>
            {
                await _fakes.UserService.CreateAsync(userFake);
            };

            var ex = await Assert.ThrowsAsync<ArgumentNullException>(action);

            Assert.IsType<ArgumentNullException>(ex);
            Assert.Equal(exMsgExpected, ex.Message);
        }

        [Fact]
        public async Task CreateUser_UserEmailInvalidFormat_ThrowException()
        {
            var userFake = _fakes.GetUsers().First();
            userFake.Email = "formaterror";
            var exMsgExpected = "The specified string is not in the form required for an e-mail address.";

            Func<Task> action = async () =>
            {
                await _fakes.UserService.CreateAsync(userFake);
            };

            var ex = await Assert.ThrowsAsync<FormatException>(action);

            Assert.IsType<FormatException>(ex);
            Assert.Equal(exMsgExpected, ex.Message);
        }

        [Fact]
        public async Task CreateUser_UserEmailExits_ThrowException()
        {
            var userFake = _fakes.GetUserShared();
            var userExpected = _fakes.GetUserBL();
            string exMsgExpected = $"The User {userFake.Name} is alredy exist";
            
            _fakes.mapperMock.Setup(mapp => mapp.Map<UserBL>(It.IsAny<UserShared>())).Returns(userExpected);
            _fakes.unitOfWorkMock.Setup(uow => uow.GetRepository<User>()).Returns(_fakes.userRepositoryMock.Object);
            _fakes.userRepositoryMock.Setup(ur => ur.GetOneAsync(It.IsAny<Expression<Func<User, bool>>>(),null)).ReturnsAsync(new User());

            Func<Task> action = async () =>
            {
                await _fakes.UserService.CreateAsync(userFake);
            };

            var ex = await Assert.ThrowsAsync<InvalidOperationException>(action);

            Assert.IsType<InvalidOperationException>(ex);
            Assert.Equal(exMsgExpected, ex.Message);
        }

        //[Fact]
        //public async Task CreateUser_UserAvailable_ReturnOK()
        //{
        //    var userFake = _fakes.GetUserShared();
        //    var userBLExpected = _fakes.GetUserBL();
        //    var giftExpected = _fakes.GetGift();
        //    var userExpected = _fakes.GetUser();

        //    _fakes.mapperMock.Setup(mapp => mapp.Map<UserBL>(It.IsAny<UserShared>())).Returns(userBLExpected);
        //    _fakes.unitOfWorkMock.Setup(uow => uow.GetRepository<User>()).Returns(_fakes.userRepositoryMock.Object);
        //    _fakes.userRepositoryMock.Setup(ur => ur.GetOneAsync(It.IsAny<Expression<Func<User, bool>>>(), null)).ReturnsAsync(default(User));
        //    _fakes.giftFactoryMock.Setup(gf => gf.Create(It.IsAny<string>())).Returns(giftExpected);
        //    _fakes.mapperMock.Setup(mapp => mapp.Map<User>(It.IsAny<UserBL>())).Returns(userExpected);

        //    Func<Task> action = async () =>
        //    {
        //        await _fakes.UserService.CreateAsync(userFake);
        //    };

        //    //var ex = await Assert.ThrowsAsync<InvalidOperationException>(action);

        //    //Assert.IsType<InvalidOperationException>(ex);
        //    //Assert.Equal(exMsgExpected, ex.Message);
        //}
    }
}
