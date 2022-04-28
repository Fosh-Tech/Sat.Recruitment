using Sat.Recruitment.Entities.Common;
using Sat.Recruitment.Entities.Enums;
using Sat.Recruitment.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sat.Recruitment.Entities.Entities
{
    public class User
    {
        private List<string> _errors;

        public User(string name, string email, string address, string phone, string userType, decimal money)
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
        public decimal Money { get; set; }

        public bool HasErrors => _errors.Any();

    }
}
