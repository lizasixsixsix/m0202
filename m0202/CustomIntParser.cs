using System.Text.RegularExpressions;
using m0202.Exceptions;

namespace m0202
{
    public class CustomIntParser
    {
        public static bool TryParse(string str,
                                    out int result)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new CustomIntParserException("String cannot be empty.");
            }

            str = str.Trim();

            Match match = Regex.Match(str, "^-?[0-9a-fA-F]+$");

            if (!match.Success)
            {
                throw new CustomIntParserException("This is not a decimal integer.");
            }

            result = 0;

            return true;
        }

        public static int Parse(string str)
        {
            return 0;
        }
    }
}
