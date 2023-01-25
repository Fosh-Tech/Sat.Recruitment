using AutoMapper;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Core.Models;

namespace Sat.Recruitment.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserShared, User>().ReverseMap();
        }
    }
}
