using System.Linq;

namespace GISA.Core.Utils
{
    public static class StringUtils
    {
        public static string ApenasNumeros(this string input)
            => new string(input.Where(char.IsDigit).ToArray());
    }
}