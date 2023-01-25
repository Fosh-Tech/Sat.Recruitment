using AutoMapper;
using Sat.Recruitment.Business.Concrete;
using Sat.Recruitment.Business.Interfaces;
using Sat.Recruitment.Core.Extensions;
using Sat.Recruitment.Core.Models;
using Sat.Recruitment.Core.Services;
using System;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Services
{
    public class UserService : IUserService
    {
        readonly IGiftFactory friendlyGiftFactory;
        readonly IMapper mapper;
        public UserService(IGiftFactory friendlyGiftFactory, IMapper mapper)
        {
            this.friendlyGiftFactory = friendlyGiftFactory;
            this.mapper = mapper;
        }

        public async Task CreateAsync(UserShared userShared)
        {
            Validate(userShared);
            var user = mapper.Map<User>(userShared);

            //var entity = await userRepository.GetOneAsync(x => x.Mail == user.Email || x.Phone == user.Phone || (x.Name == user.Name && x.Address == user.Address));
            //if (entity == null)
            //    throw new InvalidOperationException($"TheUser {user.Email} is alredy exist");

            var gift = friendlyGiftFactory.Create(user.Type.ToLower());
            gift.ApplyToUser(user);

            //try
            //{
            //    await userRepository.InsertAsync(user);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
        }

        private void Validate(UserShared user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(User));
            if (string.IsNullOrEmpty(user.Email))
                throw new ArgumentNullException(string.Format(@"{0} -> {1}",nameof(User), nameof(User.Email)));
            if (!user.Email.IsMailAdress())
                throw new ArgumentNullException(string.Format(@"{0} -> {1}",nameof(User), nameof(User.Email)));
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
