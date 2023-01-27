using AutoMapper;
using Moq;
using Sat.Recruitment.Api.DTOs.User;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Data.Context;
using Sat.Recruitment.Data.Repositories;
using Sat.Recruitment.Service.Services;
using System.Collections.Generic;

namespace Sat.Recruitment.Service.Test.Fakes
{
    public class UserServiceFakes
    {

        public Mock<IGiftFactory> giftFactoryMock { get; set; }
        public Mock<IMapper> mapperMock { get; set; }
        public Mock<IUnitOfWork> unitOfWorkMock { get; set; }
        public Mock<IRepository<User>> userRepositoryMock { get; set; }
        public UserService UserService { get; set; }


        public UserServiceFakes()
        {
            giftFactoryMock = new Mock<IGiftFactory>();
            mapperMock = new Mock<IMapper>();
            unitOfWorkMock = new Mock<IUnitOfWork>();
            userRepositoryMock = new Mock<IRepository<User>>();
            UserService = new UserService(giftFactoryMock.Object, mapperMock.Object, unitOfWorkMock.Object);
        }

        public List<CreateUserRequest> GetCreateUserRequestList()
        {
            return new List<CreateUserRequest>()
            {
                new CreateUserRequest()
                {
                    Name = "Mike", 
                    Email = "mike@gmail.com", 
                    Address = "Av. Juan G", 
                    Phone = "+349 1122354215", 
                    Type = "Normal", 
                    Money = 124
                },
                new CreateUserRequest()
                {
                    Name = "Agustina",
                    Email = "Agustina@gmail.com",
                    Address = "Av. Juan G",
                    Phone = "+349 1122354215", 
                    Type = "Normal", 
                    Money = 124
                },
                new CreateUserRequest()
                {
                    Name = "Messi",
                    Email = "Messi@gmail.com",
                    Address = "calle campeon 2022",
                    Phone = "3",
                    Type = "SuperUser",
                    Money = 400
                }
            };
        }

        public UserBL GetEmptyUser()
            => new UserBL();

        public CreateUserRequest GetCreateUserRequest()
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
        public UserBL GetUserBL()
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
        public GiftNormal GetGift()
        {
            return new GiftNormal();
        }

        public User GetUser()
        {
            return new User()
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
