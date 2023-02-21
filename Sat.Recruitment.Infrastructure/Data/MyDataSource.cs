using Sat.Recruitment.Application.Data;
using Sat.Recruitment.Domain.Entities;
using Sat.Recruitment.Domain.Enums;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace Sat.Recruitment.Infrastructure.Data
{
    public class MyDataSource : IMyDataSource
    {
        private List<User> _users = new();

        private readonly string _dataSourceFilePath;
        private const char _stringSeparator = ',';

        public MyDataSource(string dataSourceFilePath)
        {
            _dataSourceFilePath = dataSourceFilePath;
            _users = GetAllUsers();
        }

        public async Task<User> CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            var sb = new StringBuilder();

            var objectProperties = user
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x != null && x.GetCustomAttribute<JsonPropertyOrderAttribute>() != null)
                .Select(x =>
                new
                {
                    Property = x,
                    x.GetCustomAttribute<JsonPropertyOrderAttribute>().Order
                })
                .OrderBy(x => x.Order)
                .ToList();

            sb.AppendLine();

            for (int i = 0; i < objectProperties.Count; i++)
            {
                if (i != objectProperties.Count - 1)
                {
                    sb.Append(objectProperties[i].Property.GetValue(user));
                    sb.Append(_stringSeparator);
                }
                else
                    sb.Append(objectProperties[i].Property.GetValue(user));
            }
            using StreamWriter file = new(_dataSourceFilePath, append: true);
            await file.WriteLineAsync(sb, cancellationToken);

            _users.Add(user);

            return user;
        }
        public async Task<IQueryable<User>> GetAllUsersAsync() =>
            await Task.Run(() => _users.AsQueryable());

        private List<User> GetAllUsers()
        {
            var result = new List<User>();

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            var allLines = File.ReadAllLines(_dataSourceFilePath);

            foreach (var line in allLines)
            {
                var userFieldsAsText = line.Split(_stringSeparator).Where(x => !string.IsNullOrEmpty(x)).Select(y => y.Trim().ToLower()).ToList();

                if (userFieldsAsText.Count != 6)
                    throw new ApplicationException($"Invalid Schema - Application Source at {_dataSourceFilePath} is not well formed and contains an invalid quantity of fields ");

                var name = userFieldsAsText[0];
                var email = userFieldsAsText[1];
                var phone = userFieldsAsText[2];
                var address = userFieldsAsText[3];
                var userType = string.IsNullOrEmpty(userFieldsAsText[4]) ? UserTypeEnum.Normal : (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), userFieldsAsText[4], true);
                var money = decimal.Zero;

                if (!decimal.TryParse(userFieldsAsText[5], out money))
                    throw new ApplicationException($"Invalid Value Types - Application Source at {_dataSourceFilePath} is not well formed and contains invalid values.");

                result.Add(new User(name, email, address, phone, userType, money));
            }

            return result;
        }
    }
}
