namespace SkiResorts.Web.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public static class EnumExtensions
    {
        public static string ToFriendlyEnum(this Enum input, string delimeter = " ")
        {
            return input.ToString().Any(char.IsUpper) ? string.Join(delimeter, Regex.Split(input.ToString(), "(?<!^)(?=[A-Z])")) : input.ToString();
        }
    }
}
