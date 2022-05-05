using Sat.Recruitment.Model.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Services
{
    public class UserReaderService : IUserReaderService
    {
        private readonly string _file = "Users.txt";

        public async Task<List<User>> GetAllAsync()
        {

            using FileStream fileStream = new FileStream(Path.Combine(Environment.CurrentDirectory, "Files", _file), FileMode.Open);
            using StreamReader reader = new StreamReader(fileStream);
            List<User> users = new List<User>();

            var line = string.Empty;

            while (!string.IsNullOrEmpty(line = await reader.ReadLineAsync()))
            {
                var splitted = line.Split(',');

                var newUser = new User
                {
                    Name = splitted[0],
                    Email = splitted[1],
                    Phone = splitted[2],
                    Address = splitted[3],
                    UserType = splitted[4],
                    Money = Convert.ToDecimal(splitted[5]),
                };

                users.Add(newUser);
            }

            return users;
        }


    }
}
