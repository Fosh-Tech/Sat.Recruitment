using Moq;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Business.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Sat.Recruitment.Business.Test.Fakes
{
    public class GiftFactoryFakes
    {
        public UserBL GetUserNormal()
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

        public UserBL GetUserPremium()
        {
            return new UserBL()
            {
                Name = "Agustina",
                Email = "Agustina@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                Type = "Premium",
                Money = 124
            };
        }

        public UserBL GetUserSuper()
        {
            return new UserBL()
            {
                Name = "Messi",
                Email = "Messi@gmail.com",
                Address = "calle campeon 2022",
                Phone = "3",
                Type = "SuperUser",
                Money = 400
            };
        }
    }
}
