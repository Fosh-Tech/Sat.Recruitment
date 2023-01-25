using Sat.Recruitment.Business.Interfaces;

namespace Sat.Recruitment.Business.Concrete
{
    public class UserBL : IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public decimal Money { get; set; }
    }
}
