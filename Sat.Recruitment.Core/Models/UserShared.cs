using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Core.Models
{
    public class UserShared
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Money { get; set; }
    }
}
