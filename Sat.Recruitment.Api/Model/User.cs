namespace Sat.Recruitment.Api.Model
{
    /// <summary>
    /// Contains the data relative to an user.
    /// </summary>
    internal sealed class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }
    }
}
