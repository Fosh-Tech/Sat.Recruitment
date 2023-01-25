using Sat.Recruitment.Business.Interfaces;
using System;

namespace Sat.Recruitment.Business.Concrete
{
    public class UserNormal : IUser
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
        //    //TODO: review this logic.
        //    if (Money > 100)
        //    {
        //        var percentage = Convert.ToDecimal(0.12);
        //        //If new user is normal and has more than USD100
        //        var gif = Money * percentage;
        //        Money += gif;
        //    }

        //    if (Money < 100)
        //    {
        //        if (Money > 10)
        //        {
        //            var percentage = Convert.ToDecimal(0.8);
        //            var gif = Money * percentage;
        //            Money += gif;
        //        }
        //    }
        //}
    }
}
