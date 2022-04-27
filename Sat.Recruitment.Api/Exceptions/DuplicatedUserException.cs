using System;

namespace Sat.Recruitment.Api.Exceptions
{
    public class DuplicatedUserException : Exception
    {
        public DuplicatedUserException(string message) : base(message)
        {

        }
    }
}
