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

        public User(string name, string email, string address, string phone, UserTypes userType, decimal money)
        {
            _errors = new List<string>();

            if (string.IsNullOrEmpty(name))
            {
                _errors.Add(Constants.NAME_IS_MANDATORY);
            }

            if (string.IsNullOrEmpty(email))
            {
                _errors.Add(Constants.EMAIL_IS_MANDATORY);
            }

            if (string.IsNullOrEmpty(address))
            {
                _errors.Add(Constants.ADDRESS_IS_MANDATORY);
            }

            if (string.IsNullOrEmpty(phone))
            {
                _errors.Add(Constants.PHONE_IS_MANDATORY);
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

        public bool HasErrors => _errors.Any();

        public string GetErrors()
        {
            StringBuilder errorMessage = new StringBuilder();

            for (int i = 0; i < _errors.Count; i++)
            {
                errorMessage.Append(_errors[i]);
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

            if (aux.Length < 2)
            {
                throw new EMailException();
            }

            int atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }
    }
}
