using Sat.Recruitment.Shared.Models.Configuration.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Shared.Models.Configuration.Implementations
{
    public sealed class CorsSettings : ICorsSettings
    {
        [Required]
        public Policy[] Policies { get; set; }
    }
}
