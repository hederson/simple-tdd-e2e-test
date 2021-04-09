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

        private readonly char[] upperCaseLetters = new char[] {
               'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };

        private readonly char[] lowerCaseLetters = new char[] {
               'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };

        private readonly char[] numbers = new char[]
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        private readonly char[] specialCharactersAllowed = new char[]
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
                                                (numbers.Any(n => n == letter) ||
                                                upperCaseLetters.Any(u => u == letter) ||
                                                lowerCaseLetters.Any(l => l == letter) ||
                                                specialCharactersAllowed.Any(s => s == letter)));

            return validated;
        }
    }
}
