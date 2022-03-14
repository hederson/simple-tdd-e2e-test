using SimplePasswordCheck.Core.Password.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Core.Password.Service
{
    public class PasswordValidatorService : IPasswordValidatorService
    {  

        private static readonly char[] UpperCaseLetters = new char[] {
               'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

        private static readonly char[] LowerCaseLetters = new char[] {
               'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };

        private static readonly char[] Numbers = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        private static readonly char[] SpecialCharactersAllowed = new char[]
       {           
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+'
       };
        
        public bool Validate(string password)
        {
            if (password.Length < 9)
                return false;

            bool invalidPassword = password.Any(letter => (password.Count(p => p == letter) > 1) || letter.Equals((char)32));

            if(invalidPassword)
            {
                return false;
            }

            bool validated = password.Any(letter =>                                                
                                                (Numbers.Any(n => n == letter) ||
                                                UpperCaseLetters.Any(u => u == letter) ||
                                                LowerCaseLetters.Any(l => l == letter) ||
                                                SpecialCharactersAllowed.Any(s => s == letter)));

            return validated;
        }
    }
}
