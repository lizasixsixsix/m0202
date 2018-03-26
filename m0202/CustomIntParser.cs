using System;
using System.Linq;
using System.Text.RegularExpressions;
using m0202.Exceptions;

namespace m0202
{
    public static class CustomIntParser
    {
        public static int Parse(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new CustomIntParserException("String cannot be empty.");
            }

            str = str.Trim();

            if (!Regex.Match(str, "^-?[0-9a-fA-F]+$").Success)
            {
                throw new CustomIntParserException("This is not a decimal integer.");
            }

            bool isNegative = Regex.Match(str, "^-{1}").Success;

            if (isNegative)
            {
                str = str.Substring(1);
            }

            int number;

            try
            {
                number = StringToInt(str);
            }
            catch (OverflowException)
            {
                throw new CustomIntParserException("Integer overflow.");
            }

            return isNegative ? -number : number;
        }

        private static int StringToInt(string str)
        {
            int result = str.Aggregate(
                0,
                (number, digit) => checked(number * 10 + (digit - '0')));

            return result;
        }
    }
}
