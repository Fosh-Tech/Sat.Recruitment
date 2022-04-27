using System;

namespace Sat.Recruitment.Api.Exceptions
{
    public class IocException : Exception
    {
        public IocException(string message) : base(message)
        {

        }
    }
}
