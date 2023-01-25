using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sat.Recruitment.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool IsMailAdress(this string value)
        {
            var addr = new System.Net.Mail.MailAddress(value);
            bool isMailAdress = addr.Address == value;
            return isMailAdress;
        }
    }
}
