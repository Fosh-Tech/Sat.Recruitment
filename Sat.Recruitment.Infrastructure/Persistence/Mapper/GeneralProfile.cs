using AutoMapper;
using Sat.Recruitment.Application.Common.ViewModels;
using Sat.Recruitment.Domain.Users;

namespace Sat.Recruitment.Infrastructure.Persistence.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
        }
    }
}