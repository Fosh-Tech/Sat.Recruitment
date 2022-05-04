using System;
using System.Net.Mail;

namespace Sat.Recruitment.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string NormalizeMail(this string input)
        {
            if (!input.IsMail())
                return input;

            var splitted = input.Split('@');

            var indexAt = splitted[0].IndexOf('+');
            if (indexAt >= 0)
                splitted[0] = splitted[0].Remove(indexAt);

            return string.Join('@', splitted[0].Replace(".", string.Empty), splitted[1]);
        }

        public static bool IsMail(this string input)
        {
            try
            {
                var addr = new MailAddress(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
