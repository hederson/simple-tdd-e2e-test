using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Core.Password.Application.Dto
{
    public class PasswordValidationResponse
        {
        /// <summary>
        /// Validation result
        /// </summary>
        public bool Valid { get; set; }
    }
}
