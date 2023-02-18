using System.Net.Mail;

namespace Sat.Recruitment.Domain;

public class User
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string UserType { get; set; } = null!;
    public decimal Money { get; set; }

    /// <summary>
    /// Money gif for new users.
    /// </summary>
    public void ApplyNewUserGif()
    {
        if (UserType == "Normal")
        {
            if (Money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                var gif = Money * percentage;
                Money += gif;
            }
            if (Money < 100)
            {
                if (Money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    var gif = Money * percentage;
                    Money += gif;
                }
            }
        }
        if (UserType == "SuperUser")
        {
            if (Money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = Money * percentage;
                Money += gif;
            }
        }
        if (UserType == "Premium")
        {
            if (Money > 100)
            {
                var gif = Money * 2;
                Money += gif;
            }
        }
    }

    public void NormalizeEmail()
    {
        var aux = Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
        var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
        aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
        Email = string.Join("@", new string[] { aux[0], aux[1] });
    }
}
