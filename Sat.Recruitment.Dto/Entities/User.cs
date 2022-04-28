using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sat.Recruitment.Entities.Entities
{
    public class User
    {
        public User(string name, string email, string address, string phone, string userType, string money)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            UserType = userType;
            Money = money;
        }

        public string Name { get; }
        public string Email { get; }
        public string Address { get; }
        public string Phone { get; }
        public string UserType { get; set; }
        public string Money { get; set; }

    }
}
