using System.Text.RegularExpressions;

namespace IMDBWebApi.Application.Extension
{
    public static class StringExtensions
    {
        public static bool IsValidPassword(this string password)
        {
            var expression = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[^A-Za-z0-9]).+$";
            
            return Regex.Match(password, expression).Success;
        }
    }
}
