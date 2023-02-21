using Sat.Recruitment.Shared.Models.Configuration.Implementations;

namespace Sat.Recruitment.Shared.Models.Configuration.Interfaces
{
    public interface ISecuritySettings
    {
        CorsSettings CORSSettings { get; set; }        
    }
}
