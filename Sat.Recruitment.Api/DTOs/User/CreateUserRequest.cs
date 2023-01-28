using Newtonsoft.Json.Linq;
using Sat.Recruitment.Api.Exceptions;
using Sat.Recruitment.Api.Filters;
using Sat.Recruitment.Business.Concrete;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Sat.Recruitment.Api.DTOs.User
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Money { get; set; }

        public UserBL ToDomain(CreateUserRequest createUserRequest)
        {
            ValidEmail();
            return new UserBL()
            {
                Name = createUserRequest.Name,
                Email = createUserRequest.Email,
                Address = createUserRequest.Address,
                Phone = createUserRequest.Phone,
                Type = createUserRequest.Type,
                Money = createUserRequest.Money
            };
        }
        private void ValidEmail()
        {
            if (Email == null || Email.Length == 0)
                throw new EmailFormatException($"The Email field is required.", "EMAILNULLOREMPTY_ERROR");

            bool created = MailAddress.TryCreate(Email, out MailAddress addr);
            bool isEmailAddress = created && addr.Address == Email;
            if (!isEmailAddress)
                throw new EmailFormatException($"The Email {Email} is not in correct format.", "EMAILFORMAT_ERROR");
        }

    }
}
