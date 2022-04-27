using System;

namespace Sat.Recruitment.Application.Exceptions
{
    public class IocException : Exception
    {
        public IocException(string message) : base(message)
        {

        }
    }
}
