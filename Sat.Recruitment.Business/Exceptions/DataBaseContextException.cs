using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Business.Exceptions
{
    public class DataBaseContextException : Exception
    {
        public string Code { get; set; } = "DATABASE_GENERAL_EXCEPTION";

        public DataBaseContextException(string message = null) : base(message) { }
        public DataBaseContextException(string message, Exception innerException) : base(message, innerException) { }
    }
}
