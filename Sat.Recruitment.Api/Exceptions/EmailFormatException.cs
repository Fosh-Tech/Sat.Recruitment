using System;

namespace Sat.Recruitment.Api.Exceptions
{
    public class EmailFormatException : Exception
    {
        public string Code { get; set; }
        public EmailFormatException(string message, string errorCode)
            : base(message)
        {
            Code = errorCode;
        }
    }
}
