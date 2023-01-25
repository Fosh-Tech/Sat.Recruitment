// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

using System.Xml.Linq;

namespace Sat.Recruitment.Data.Context
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public decimal? Money { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name},{Email},{Address},{Phone},{Type},{Money}");
        }
    }


}
