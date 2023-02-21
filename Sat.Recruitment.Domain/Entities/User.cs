using Sat.Recruitment.Domain.Enums;
using System.Net.Mail;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Sat.Recruitment.Domain.Entities
{
    public partial class User
    {
        [JsonPropertyOrder(0)]
        public string Name { get; private set; }

        [JsonPropertyOrder(1)]
        public string Email { get; private set; }

        [JsonPropertyOrder(2)]
        public string Address { get; private set; }

        [JsonPropertyOrder(3)]
        public string Phone { get; private set; }

        [JsonPropertyOrder(4)]
        public UserTypeEnum UserType { get; private set; }

        [JsonPropertyOrder(5)]
        public decimal Money { get; private set; } = decimal.Zero;

        public User(string name, string email, string address, string phone, UserTypeEnum userType, decimal money)
        {
            Validate(name, email, address, phone, money);

            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            UserType = userType;

            SetMoneyGiftByUserType(money);
        }

        private void SetMoneyGiftByUserType(decimal initialMoney)
        {
            var gift = decimal.Zero;

            switch (UserType)
            {
                case UserTypeEnum.Normal:
                    if (initialMoney > 100)
                        gift = initialMoney * Convert.ToDecimal(0.12);
                    else if (initialMoney > 10)
                        gift = initialMoney * Convert.ToDecimal(0.8);
                    break;
                case UserTypeEnum.SuperUser:
                    if (initialMoney > 100)
                        gift = initialMoney * Convert.ToDecimal(0.20);
                    break;
                case UserTypeEnum.Premium:
                    if (initialMoney > 100)
                        gift = initialMoney * 2;
                    break;
                default:
                    break;
            }

            Money = initialMoney + gift;
        }

        private void Validate(string name, string email, string address, string phone, decimal money)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (string.IsNullOrEmpty(email) || !IsEmailValid(email))
                throw new ArgumentNullException(nameof(email));

            if (string.IsNullOrEmpty(address))
                throw new ArgumentNullException(nameof(address));

            if (string.IsNullOrEmpty(phone) || !IsPhoneNumberValid(phone))
                throw new ArgumentNullException(nameof(phone));

            if (money == decimal.MinValue)
                throw new ArgumentNullException(nameof(money));
        }

        private static bool IsEmailValid(string email)
        {
            try { var emailAddress = new MailAddress(email); }
            catch { return false; }

            return true;
        }

        private static bool IsPhoneNumberValid(string number) =>
            IsPhoneNumberValidRegex().IsMatch(number);

        [GeneratedRegex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$")]
        private static partial Regex IsPhoneNumberValidRegex();
    }
}
