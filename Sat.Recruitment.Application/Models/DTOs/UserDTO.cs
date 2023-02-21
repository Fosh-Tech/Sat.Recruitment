using Mapster;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Application.Models.DTOs
{
    public class UserDTO : IRegister
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, UserDTO>()                 
                 .Map(dest => dest.Name, src => src.Name)
                 .Map(dest => dest.Email, src => src.Email)
                 .Map(dest => dest.Address, src => src.Address)
                 .Map(dest => dest.Phone, src => src.Phone)
                 .Map(dest => dest.UserType, src => src.UserType.ToString())
                 .Map(dest => dest.Money, src => src.Money);
        }
    }
}
