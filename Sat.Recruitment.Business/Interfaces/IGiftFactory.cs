using Sat.Recruitment.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Business.Interfaces
{
    public interface IGiftFactory
    {
        IGift Create(string type);
    }
}
