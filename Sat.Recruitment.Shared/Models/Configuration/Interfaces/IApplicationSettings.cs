using Sat.Recruitment.Shared.Models.Configuration.Implementations;

namespace Sat.Recruitment.Shared.Models.Configuration.Interfaces
{
    public interface IApplicationSettings
    {
        string ApplicationName { get; set; }        
        string DataSourceFilePath { get; set; }
        SecuritySettings SecuritySettings { get; set; }
    }
}
