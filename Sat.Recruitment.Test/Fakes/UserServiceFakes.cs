using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Business.Services;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Data.Context;
using Sat.Recruitment.Data.Repositories;
using Sat.Recruitment.Service.Services;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

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


        public List<UserShared> GetUsers()
        {
            return new List<UserShared>()
            {
                new UserShared()
                {
                    Name = "Mike", 
                    Email = "mike@gmail.com", 
                    Address = "Av. Juan G", 
                    Phone = "+349 1122354215", 
                    Type = "Normal", 
                    Money = 124
                },
                new UserShared()
                {
                    Name = "Agustina",
                    Email = "Agustina@gmail.com",
                    Address = "Av. Juan G",
                    Phone = "+349 1122354215", 
                    Type = "Normal", 
                    Money = 124
                },
                new UserShared()
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

        public UserShared GetEmptyUser()
            => new UserShared();

        public UserShared GetUserShared()
        {
            return new UserShared()
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
