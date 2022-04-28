using System;
using System.Collections.Generic;
using System.Text;
using Sat.Recruitment.Dtos.Exceptions;

namespace Sat.Recruitment.Dtos.Common
{
    internal class Utils
    {

        public decimal GetDecimal(string value)
        {
            if (!decimal.TryParse(value, out decimal parsedValue))
            {
                parsedValue = 0;
            }

            return parsedValue;
        }

        public T GetEnum<T>(string value) where T : struct
        {
            if (!Enum.TryParse<T>(value, out T type))
            {
                throw new UserTypeException();
            }

            return type;

        }

    }
}
