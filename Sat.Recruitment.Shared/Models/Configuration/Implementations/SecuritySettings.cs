using Sat.Recruitment.Shared.Models.Configuration.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Shared.Models.Configuration.Implementations
{
    public sealed class SecuritySettings : ISecuritySettings
    {
        [Required]
        public CorsSettings CORSSettings { get; set; }
    }
}
