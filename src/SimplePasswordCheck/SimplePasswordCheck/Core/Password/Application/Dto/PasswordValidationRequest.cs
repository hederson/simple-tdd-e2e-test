using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Core.Password.Application.Dto
{
    public class PasswordValidationRequest
    {
        /// <summary>
        /// Password that needs to be validated
        /// </summary>
        public string Password { get; set; }
    }
}
