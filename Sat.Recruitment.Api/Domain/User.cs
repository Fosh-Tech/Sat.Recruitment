namespace Sat.Recruitment.Api.Domain
{
    /// <summary>
    /// Contains the data relative to a valid user.
    /// </summary>
    public sealed class User
    {
        public User()
        {
            this.Name = string.Empty;
            this.Email = string.Empty;
            this.Address = string.Empty;
            this.Phone = string.Empty;
            this.UserType = string.Empty;
        }

        public User(User other)
        {
            this.Name = other.Name;
            this.Email = other.Email;
            this.Address = other.Address;
            this.Phone = other.Phone;
            this.UserType = other.UserType;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string UserType { get; set; }

        public decimal Money { get; set; }
    }
}
