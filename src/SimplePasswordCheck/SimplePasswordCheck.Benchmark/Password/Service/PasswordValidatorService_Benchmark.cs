using BenchmarkDotNet.Attributes;
using SimplePasswordCheck.Core.Password.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Benchmark.Password.Service
{  
    [MemoryDiagnoser]
    public class PasswordValidatorServiceBenchmark
    {
        [Params("AbTp9!fok",
                "AbTp9!feka",
                "AbTp9!fek123",
                "AbTp9!fek123()",
                "AbTp9!fek123)",
                "AAAbbbCc",
                "AbTp9!foo",
                "AbTp9!foA",
                "AbTp9 fok")]
        public string password { get; set; }


        [Benchmark]
        public bool ValidatePasswordLinq()
        {
            var passwordValidator = new PasswordValidatorService();
            return passwordValidator.Validate(password);
        }

        [Benchmark]
        public bool ValidatePasswordRegex()
        {
            var passwordValidator = new PasswordValidatorRegexService();
            return passwordValidator.Validate(password);
        }
    }
}
