using Sat.Recruitment.Api.Entities;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;

namespace Sat.Recruitment.Api.Persistence
{
    public class UsersReader
    {
        //TODO architect and abstract the entire persistence engine.

        /// <summary>
        /// This funcion read the user list stored in the Users.txt file.
        /// </summary>
        /// <returns></returns>
        public static List<User> readUsersFromTextFile()
        {
            try
            {
                var output = new List<User>();

                var path = Directory.GetCurrentDirectory() + "/Files/Users.txt"; //TODO fix magic string: Send to a config file.
                using (FileStream fileStream = new FileStream(path, FileMode.Open))
                {
                    using (var reader = new StreamReader(fileStream))
                    {
                        while (reader.Peek() >= 0)
                        {
                            var line = reader.ReadLineAsync().Result;
                            var splittedLine = line.Split(','); //TODO fix magic char: Send to a config file or context.

                            var userCreationParameters = new UsersCreationParameters
                            {
                                Name = splittedLine[0],
                                Email = splittedLine[1],
                                Phone = splittedLine[2],
                                Address = splittedLine[3],
                                UserType = splittedLine[4],
                                Money = decimal.Parse(splittedLine[5]),
                            };
                            var user = UsersFactory.newUser(userCreationParameters);
                            output.Add(user);
                        }
                    }
                }

                return output;
            }
            catch
            {
                throw;
            }
        }
    }
}
