namespace Sat.Recruitment.Api.Entities
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string UserType { get; set; }
        public decimal Money { get; set; }

        //Copy constructor to be used by the subclasses
        protected User(User usersCreationParameters)
        {
            Name = usersCreationParameters.Name;
            Email = usersCreationParameters.Email;
            Address = usersCreationParameters.Address;
            Phone = usersCreationParameters.Phone;
            UserType = usersCreationParameters.UserType;
            Money = usersCreationParameters.Money;
        }

        protected User() { }
    }
}