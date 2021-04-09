using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Core.Password.Interfaces
{
    public interface IPasswordValidatorService
    {
        bool Validate(string password);
    }
}
