using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Business.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public string Code { get; set; } = "ENTITY_NOTFOUND_EXCEPTION";
        public EntityNotFoundException(string message) : base(message)
        { }
    }
}
