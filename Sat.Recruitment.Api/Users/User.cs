using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Common;

namespace Sat.Recruitment.Api.Users
{
    public class User
    {
        private Queue<string> _errors;

        public User(string name, string email, string address, string phone, UserTypes userType, decimal money)
        {
            _errors = new Queue<string>();

            if (string.IsNullOrEmpty(name))
            {
                _errors.Enqueue(Constants.NAME_IS_MANDATORY);
            }

            if (string.IsNullOrEmpty(email))
            {
                _errors.Enqueue(Constants.EMAIL_IS_MANDATORY);
            }

            if (string.IsNullOrEmpty(address))
            {
                _errors.Enqueue(Constants.ADDRESS_IS_MANDATORY);
            }

            if (string.IsNullOrEmpty(phone))
            {
                _errors.Enqueue(Constants.PHONE_IS_MANDATORY);
            }

            if (!_errors.Any())
            {
                Name = name;
                Email = GetNormalizedEmail(email);
                Address = address;
                Phone = phone;
                UserType = userType;
                Money = money;
            }
        }

        public string Name { get; }
        public string Email { get; }
        public string Address { get; }
        public string Phone { get; }
        public UserTypes UserType { get; set; }
        public decimal Money { get; set; }

        public bool HasErrors => _errors.Count > 0;

        public string GetErrors()
        {
            StringBuilder errorMessage = new StringBuilder();

            for (int i = 0; i < _errors.Count; i++)
            {
                errorMessage.Append(_errors.Dequeue());
            }

            return errorMessage.ToString();
        }

        public bool IsDuplicated(User user)
        {
            return Email == user.Email || Phone == user.Phone || (Name == user.Name && Email == user.Email);
        }

        private string GetNormalizedEmail(string unNormalizedValue)
        {
            string[] aux = unNormalizedValue.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            int atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
