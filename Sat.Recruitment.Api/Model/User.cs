using System;

namespace Sat.Recruitment.Api.Model
{
    /// <summary>
    /// Contains the data relative to a valid user.
    /// </summary>
    public sealed class User
    {
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string? UserType { get; set; }

        public static User Create(string? name, string? email, string? address, string? phone, string? userType) => new User
        {
            Address = address,
            Email = email != null ? NormalizeEmail(email) : null,
            Name = name,
            Phone = phone,
            UserType = userType
        };

        private static string NormalizeEmail(string email)
        {
            try
            {
                //ReadOnlySpan<char> source = email.AsSpan();
                //ReadOnlySpan<char> address = new string(Remove(source.Slice(0, atIndex), '.').ToArray());
                //ReadOnlySpan<char> domain = source.Slice(atIndex + 1);
                int atIndex = email.IndexOf('@');
                string address = email.Substring(0, atIndex).Replace(".", string.Empty);
                string domain = email.Substring(atIndex + 1);
                return string.Join('@', address.ToString(), domain.ToString());
            }
            catch (Exception exception)
            {
                throw new FormatException($"The given email is not in valid format: '${email}'", exception);
            }

            // TODO://Normalize email
            //var aux = newUser.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            //var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            //aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            //newUser.Email = string.Join("@", new string[] { aux[0], aux[1] });
        }

        //private static IEnumerable<char> Remove(ReadOnlySpan<char> source, char pattern)
        //{
        //    for (int i = 0, n = source.Length; i < n; i++)
        //    {
        //        if (source[i] == pattern)
        //        {
        //            continue;
        //        }

        //        yield return source[i];
        //    }
        //}
    }
}
