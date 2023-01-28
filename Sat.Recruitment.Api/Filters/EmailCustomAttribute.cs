using Sat.Recruitment.Api.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Sat.Recruitment.Api.Filters
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EmailCustomAttribute : ValidationAttribute
    {
        private string ErrorMessage { get; set; }

        public EmailCustomAttribute(string _errorMessage) : base(_errorMessage)
        {
            ErrorMessage = _errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var val = (string)value;
            if (!EmailAddress(val))
                throw new EmailFormatException(ErrorMessage, $"{validationContext.MemberName.ToUpper()}FORMAT_ERROR");

            return ValidationResult.Success;
        }
        private static bool EmailAddress(string value)
        {
            try
            {
                bool created = MailAddress.TryCreate(value, out MailAddress addr);
                bool isEmailAddress = created && addr.Address == value;
                return isEmailAddress;
            }
            catch
            {
                return false;
            }
        }
    }
}
