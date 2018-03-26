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
                throw new CustomIntParserException(
                    $"Parameter {nameof(str)} cannot be an empty string.");
            }

            str = str.Trim();

            if (!Regex.Match(str, "^-?[0-9a-fA-F]+$").Success)
            {
                throw new CustomIntParserException(
                    $"Parameter {nameof(str)} does not represent" +
                    "a decimal integer.");
            }

            var isNegative = Regex.Match(str, "^-{1}").Success;

            if (isNegative)
            {
                str = str.Substring(1);
            }

            int number;

            try
            {
                number = StringToInt(str);
            }
            catch (OverflowException ex)
            {
                throw new CustomIntParserException(
                    $"Parameter {nameof(str)} represents an integer" +
                    $"which is out of limits of {typeof(int)}.",
                    ex);
            }

            return isNegative ? -number : number;
        }

        private static int StringToInt(string str)
        {
            var result = str.Aggregate(
                0,
                (number, digit) => checked(number * 10 + (digit - '0')));

            return result;
        }
    }
}
