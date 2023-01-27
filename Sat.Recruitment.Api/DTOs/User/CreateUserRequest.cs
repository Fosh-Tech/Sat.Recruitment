using Sat.Recruitment.Business.Concrete;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.DTOs.User
{
    public class CreateUserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Money { get; set; }

        public UserBL ToDomain(CreateUserRequest createUserRequest)
        {
            return new UserBL()
            { 
                Name = createUserRequest.Name,
                Email = createUserRequest.Email,
                Address = createUserRequest.Address,
                Phone = createUserRequest.Phone,
                Type = createUserRequest.Type,
                Money = createUserRequest.Money
            };
        }
    }
}
