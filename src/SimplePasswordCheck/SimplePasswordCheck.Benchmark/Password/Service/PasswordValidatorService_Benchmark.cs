using BenchmarkDotNet.Attributes;
using SimplePasswordCheck.Password.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordCheck.Benchmark.Password.Service
{  
    public class PasswordValidatorService_Benchmark
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
        public bool ValidatePasswordBenchmark()
        {
            var passwordValidator = new PasswordValidatorService();
            return passwordValidator.Validate(password);
        }

        [Benchmark]
        public bool ValidatePasswordWithRegexdBenchmark()
        {
            var passwordValidator = new PasswordValidatorService();
            return passwordValidator.ValidateWithRegex(password);
        }
    }
}
