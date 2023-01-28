using System;

namespace Sat.Recruitment.Api.Exceptions
{
    public class FieldMandatoryException : Exception
    {
        public string Code { get; set; }
        public FieldMandatoryException(string message, string ErrorCode) : base(message)
        {
            Code = ErrorCode;
        }
    }
}
