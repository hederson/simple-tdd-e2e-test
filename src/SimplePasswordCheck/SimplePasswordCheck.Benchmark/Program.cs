using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using SimplePasswordCheck.Password.Service;
using System;

namespace SimplePasswordCheck.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
