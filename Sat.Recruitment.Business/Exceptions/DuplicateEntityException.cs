using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business.Exceptions
{
    public class DuplicateEntityException : Exception
    {
        public string Code { get; private set; } = "DUPLICATE_ENTITY_ERROR";
        public DuplicateEntityException(string message) : base(message)
        { }
    }
}
