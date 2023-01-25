using Sat.Recruitment.Business.Interfaces;
using System;

namespace Sat.Recruitment.Business.Concrete
{
    public class UserSuper : IUser
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
        //        var percentage = Convert.ToDecimal(0.20);
        //        var gif = Money * percentage;
        //        Money += gif;
        //    }
        //}
    }
}
