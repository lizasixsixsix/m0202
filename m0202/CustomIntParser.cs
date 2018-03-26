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

            return isNegative ? -StringToInt(str) : StringToInt(str);
        }

        private static int StringToInt(string str)
        {
            return str.Aggregate(
                0,
                (number, digit) => number * 10 + (digit - '0'));
        }
    }
}
