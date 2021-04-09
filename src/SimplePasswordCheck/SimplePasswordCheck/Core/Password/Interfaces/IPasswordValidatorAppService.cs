using SimplePasswordCheck.Core.Password.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Core.Password.Interfaces
{
    public interface IPasswordValidatorAppService
    {
        PasswordValidationResponse Validate(PasswordValidationRequest request);
    }
}
