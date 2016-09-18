using System;
using static System.Text.Encoding;
using Convert = System.Convert;

namespace WebApi.Common.Utility
{
    public static class CredentialManager
    {
        public static string EncodedCredentials(string username, string password)
        {
            var unencodedString = $"{username}:{password}";

            var encodedString = Convert.ToBase64String(ASCII.GetBytes(unencodedString));

            return encodedString;
        }

        public static string DecodeCredentials(string credential)
        {
            var decodedAuth = UTF8.GetString(Convert.FromBase64String(credential));

            return decodedAuth;
        }
    }
}
