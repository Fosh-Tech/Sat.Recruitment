using Sat.Recruitment.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Application.Models.Requests
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [Required]        
        public UserTypeEnum UserType { get; set; }

        [Required]        
        public decimal Money { get; set; }
    }
}
