using Sat.Recruitment.Domain.Common;

namespace Sat.Recruitment.Domain.Users
{
    public class User : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}