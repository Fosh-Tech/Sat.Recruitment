using Sat.Recruitment.Business.Concrete;

namespace Sat.Recruitment.Api.DTOs.User
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public decimal? Money { get; set; }

        public static CreateUserResponse FromContext(Data.Context.User user)
        {
            CreateUserResponse response = new();
            
            response.Id = user.Id;
            response.Name = user.Name;
            response.Email = user.Email;
            response.Address = user.Address;
            response.Phone = user.Phone;
            response.Type = user.Type;
            response.Money = user.Money;

            return response;
        }
    }
}
