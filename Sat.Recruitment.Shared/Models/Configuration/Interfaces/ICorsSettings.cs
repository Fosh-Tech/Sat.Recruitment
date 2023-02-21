using Sat.Recruitment.Shared.Models.Configuration.Implementations;

namespace Sat.Recruitment.Shared.Models.Configuration.Interfaces
{
    public interface ICorsSettings
    {
        Policy[] Policies { get; set; }
    }
}
