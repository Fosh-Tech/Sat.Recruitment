using Sat.Recruitment.Shared.Models.Configuration.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Shared.Models.Configuration.Implementations
{
    public sealed class Policy : IPolicy
    {
        [Required]
        public string Name { get; set; }

        public string[] Origins { get; set; }

        public string[] ExposedHeaders { get; set; }

        public string[] Headers { get; set; }

        public string[] Methods { get; set; }
    }
}
