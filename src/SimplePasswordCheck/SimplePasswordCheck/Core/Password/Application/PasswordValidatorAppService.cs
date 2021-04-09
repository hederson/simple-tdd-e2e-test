using SimplePasswordCheck.Core.Password.Application.Dto;
using SimplePasswordCheck.Core.Password.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Core.Password.Application
{
    public class PasswordValidatorAppService : IPasswordValidatorAppService
    {
        private readonly IPasswordValidatorService _validatorService;

        public PasswordValidatorAppService(IPasswordValidatorService validatorService)
        {
            this._validatorService = validatorService;
        }

        public PasswordValidationResponse Validate(PasswordValidationRequest request)
        {
            var isValid = _validatorService.Validate(request.Password);


            return new PasswordValidationResponse
            {
                Valid = isValid
            };
        }
    }
}
