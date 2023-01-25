using AutoMapper;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Data.Context;

namespace Sat.Recruitment.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserShared, UserBL>().ReverseMap();
            CreateMap<UserBL, User>().ReverseMap();
        }
    }
}
