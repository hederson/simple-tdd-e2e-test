using SimplePasswordCheck.Core.Password.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Core.Password.Service
{
    public class PasswordValidatorRegexService : IPasswordValidatorService
    {  
        public bool Validate(string password)
        {
            if (password.Length < 9)
                return false;

            var passValidation =  Regex.IsMatch(password, "^(?:([A-Za-z0-9!@#$%^&*\\(\\)\\-+])(?!.*\\1))*$");

            return passValidation;
        }
    }
}
