using System;
using System.Collections.Generic;
using System.IO;
using Sat.Recruitment.Api.Applications;
using Sat.Recruitment.Api.Common;
using Sat.Recruitment.Api.Users;

namespace Sat.Recruitment.Api.Services
{
    public class UsersService : IUsersService
    {
        List<User> IUsersService.GetAllUsers()
        {
            return null;

            /*
            var reader = ReadUsersFromFile();

            //Normalize email
            var aux = newUser.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            newUser.Email = string.Join("@", new string[] { aux[0], aux[1] });

            while (reader.Peek() >= 0)
            {
                var line = reader.ReadLineAsync().Result;
                var user = new User
                {
                    Name = line.Split(',')[0].ToString(),
                    Email = line.Split(',')[1].ToString(),
                    Phone = line.Split(',')[2].ToString(),
                    Address = line.Split(',')[3].ToString(),
                    UserType = line.Split(',')[4].ToString(),
                    Money = decimal.Parse(line.Split(',')[5].ToString()),
                };
                _users.Add(user);
            }
            reader.Close();
            */


        }


        private StreamReader ReadUsersFromFile()
        {
            string path = $"{Directory.GetCurrentDirectory()}{Constants.FILE_PATH}";
            FileStream fileStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fileStream);

            return reader;
        }

    }
}
