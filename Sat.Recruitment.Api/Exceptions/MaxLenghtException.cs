using System;

namespace Sat.Recruitment.Api.Exceptions
{
    public class MaxLenghtException : Exception
    {
        public string Code { get; set; }
        public MaxLenghtException(string message, string errorCode)
            : base(message)
        { 
            Code = errorCode;
        }
    }
}
