using Sat.Recruitment.Shared.Models.Configuration.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Shared.Models.Configuration.Implementations
{
    public class ApplicationSettings : IApplicationSettings
    {
        [Required]
        public string ApplicationName { get; set; }

        [Required]
        public string DataSourceFilePath { get; set; }

        [Required]
        public SecuritySettings SecuritySettings { get; set; }
    }
}
