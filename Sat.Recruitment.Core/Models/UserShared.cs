using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Sat.Recruitment.Core.Models
{
    public class UserShared
    {
        public int Id { get; set; }
        [BindRequired]
        public string Name { get; set; }
        [BindRequired]
        public string Email { get; set; }
        [BindRequired]
        public string Address { get; set; }
        [BindRequired]
        public string Phone { get; set; }
        [BindRequired]
        public string Type { get; set; }
        [BindRequired]
        public decimal Money { get; set; }
    }
}
