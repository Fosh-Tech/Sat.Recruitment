using Sat.Recruitment.Business.Interfaces;

namespace Sat.Recruitment.Business.Concrete
{
    public class UserPremium : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public decimal Money { get; set; }

        //public void ApplyGift()
        //{
        //    if (Money > 100)
        //    {
        //        var gif = Money * 2;
        //        Money += gif;
        //    }
        //}
    }
}
