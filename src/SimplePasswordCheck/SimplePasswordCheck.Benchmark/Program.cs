using BenchmarkDotNet.Running;
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
