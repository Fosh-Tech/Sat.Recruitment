using AutoMapper;
using Sat.Recruitment.Dto.Dtos;
using Sat.Recruitment.ExtensionMethods;
using Sat.Recruitment.Model.Models;

namespace Sat.Recruitment.Dto.Profiles
{
    internal class UserProfiles : Profile
    {
        public UserProfiles()
        {
            this.CreateMap<User, UserDto>();
            this.CreateMap<UserDto, User>()
                .ForMember(dst => dst.Email, opt => opt.MapFrom(src => src.Email.NormalizeMail()));
        }
    }
}
