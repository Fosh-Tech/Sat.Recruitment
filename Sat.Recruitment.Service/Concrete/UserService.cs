using Sat.Recruitment.Core.Models;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Services
{
    public class UserService : IUserService
    {
        public Task CreateAsync(UserShared user)
        {
            switch (user.Type)
            {
                case "Normal":
                    CreateNormal(user);
                    break;
                case "SuperUser":
                    CreateSuperUser(user);
                    break;
                case "Premium":
                    CreatePremium(user);
                    break;
                //default:
                //    return "Error en User Type";
            }
            //luego lee todos los usuarios del archivo y se fija si no está duplicado. Si no lo está, lo crea...

            return Task.CompletedTask;
        }

        private void CreateNormal(UserShared user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                var gif = user.Money * percentage;
                user.Money += gif;
            }

            if (user.Money < 100)
            {
                if (user.Money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    var gif = user.Money * percentage;
                    user.Money += gif;
                }
            }
        }

        private void CreateSuperUser(UserShared user)
        {
            if (user.Money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = user.Money * percentage;
                user.Money += gif;
            }
        }

        private void CreatePremium(UserShared user)
        {
            if (user.Money > 100)
            {
                var gif = user.Money * 2;
                user.Money += gif;
            }
        }
        
        //FRUTA DEL DUPLICADO (normaliza el email no sé xq)
        //var reader = ReadUsersFromFile();

        ////Normalize email
        //var aux = user.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

        //var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

        //aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

        //user.Email = string.Join("@", new string[] { aux[0], aux[1] });

        //while (reader.Peek() >= 0)
        //{
        //    var line = reader.ReadLineAsync().Result;
        //    var user = new User
        //    {
        //        Name = line.Split(',')[0].ToString(),
        //        Email = line.Split(',')[1].ToString(),
        //        Phone = line.Split(',')[2].ToString(),
        //        Address = line.Split(',')[3].ToString(),
        //        UserType = line.Split(',')[4].ToString(),
        //        Money = decimal.Parse(line.Split(',')[5].ToString()),
        //    };
        //    _users.Add(user);
        //}
        //reader.Close();

        //try
        //{
        //    var isDuplicated = false;
        //    foreach (var user in _users)
        //    {
        //        if (user.Email == user.Email
        //            ||
        //            user.Phone == user.Phone)
        //        {
        //            isDuplicated = true;
        //        }
        //        else if (user.Name == user.Name)
        //        {
        //            if (user.Address == user.Address)
        //            {
        //                isDuplicated = true;
        //                throw new Exception("User is duplicated");
        //            }

        //        }
        //    }

        //    if (!isDuplicated)
        //    {
        //        Debug.WriteLine("User Created");

        //        return new Result()
        //        {
        //            IsSuccess = true,
        //            Errors = "User Created"
        //        };
        //    }
        //    else
        //    {
        //        Debug.WriteLine("The user is duplicated");

        //        return new Result()
        //        {
        //            IsSuccess = false,
        //            Errors = "The user is duplicated"
        //        };
        //    }
        //}
        //catch
        //{
        //    Debug.WriteLine("The user is duplicated");
        //    return new Result()
        //    {
        //        IsSuccess = false,
        //        Errors = "The user is duplicated"
        //    };
        //}
    }
}
