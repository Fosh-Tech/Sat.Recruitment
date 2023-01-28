using Moq;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Exceptions;
using Sat.Recruitment.Data.Context;
using Sat.Recruitment.Service.Test.Fakes;
using System;
using System.Linq;
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
        public async Task CreateUserAsync_DuplicateUser_ThrowException()
        {
            UserBL newUserBL = _fakes.GetUserBL();
            User newUserDAL = _fakes.GetUser();
            string exCodeExpected = "DUPLICATE_ENTITY_ERROR";
            string exMessageExpected = $"The User {newUserBL.Name} is already exist.";

            _fakes.unitOfWorkMock.Setup(uow => uow.GetRepository<User>()).Returns(_fakes.userRepositoryMock.Object);
            _fakes.userRepositoryMock.Setup(ur => ur.GetOneAsync(It.IsAny<Expression<Func<User, bool>>>(), null)).ReturnsAsync(newUserDAL);

            Func<Task> action = async () =>
            {
                await _fakes.UserService.CreateAsync(newUserBL);
            };
            var ex = await Assert.ThrowsAsync<DuplicateEntityException>(action);

            Assert.IsType<DuplicateEntityException>(ex);
            Assert.Equal(exMessageExpected, ex.Message);
            Assert.Equal(exCodeExpected, ex.Code);
        }
    }
}
