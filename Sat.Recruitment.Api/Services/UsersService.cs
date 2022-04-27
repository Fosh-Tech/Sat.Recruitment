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
            List<User> users = new List<User>();

            StreamReader usersStream = ReadUsersFromFile();

            while (usersStream.Peek() >= 0)
            {
                string line = usersStream.ReadLineAsync().Result;

                User currentUser = CreateUser(line);

                if (!currentUser.HasErrors)
                {
                    users.Add(currentUser);
                }
            }
            usersStream.Close();

            return users;
        }

        private User CreateUser(string record)
        {
            string name = record.Split(Constants.FIELD_SEPARATOR)[0].ToString();
            string email = record.Split(Constants.FIELD_SEPARATOR)[1].ToString();
            string phone = record.Split(Constants.FIELD_SEPARATOR)[2].ToString();
            string address = record.Split(Constants.FIELD_SEPARATOR)[3].ToString();
            string type = record.Split(Constants.FIELD_SEPARATOR)[4].ToString();
            decimal money = decimal.Parse(record.Split(Constants.FIELD_SEPARATOR)[5].ToString());

            UserTypes userType = Enum.Parse<UserTypes>(type);

            return new User(name, email, address, phone, userType, money);
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
