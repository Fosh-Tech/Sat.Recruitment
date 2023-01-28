using Sat.Recruitment.Api.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Filters
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class StringLenghtAttribute : ValidationAttribute
    {
        private int maxLenght { get; set; }
        private int minLenght { get; set; }
        private string errorMessage { get; set; }

        private StringLenghtAttribute(int _maxLenght, int _minLenght, string _errorMessage)
        {
            maxLenght = _maxLenght;
            minLenght = _minLenght;
            errorMessage = _errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var val = (string)value;
            if (val.Length > maxLenght)
                throw new MaxLenghtException(errorMessage, $"{validationContext.MemberName.ToUpper()}_MAXLENGHT_ERROR");

            if (val.Length < minLenght)
                throw new MaxLenghtException(errorMessage, $"{validationContext.MemberName.ToUpper()}_MINLENGHT_ERROR");

            return ValidationResult.Success;
        }
    }
}
