using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Business.Interfaces
{
    public interface IUserFactory
    {
        IUser Create(string type);
    }
}
