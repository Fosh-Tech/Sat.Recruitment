using Moq;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Data.Context;
using Sat.Recruitment.Service.Test.Fakes;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

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
            UserBL userFake = null;
            var exMsgExpected = "Value cannot be null. (Parameter 'UserBL')";

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
            UserBL userFake = new UserBL();
            var exMsgExpected = "Value cannot be null. (Parameter 'UserBL -> Email')";

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
            var userFake = _fakes.GetUserBL();
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
            var userFake = _fakes.GetUserBL();
            string exMsgExpected = $"The User {userFake.Name} is alredy exist";
            
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
    }
}
