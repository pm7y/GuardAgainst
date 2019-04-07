using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    // ReSharper disable once InconsistentNaming
    public class Benchmark
    {
        [MethodImpl(MethodImplOptions.NoOptimization)]
        // ReSharper disable once InconsistentNaming
        public static void Do(Action work, int iterations, string name, ITestOutputHelper output = null, double targetExecutionTime = 0.01D)
        {
            var s = Stopwatch.StartNew();

            for (var i = 0; i < iterations; i++)
            {
                work.Invoke();
            }

            s.Stop();
            var avgExecutionTime = s.ElapsedMilliseconds / (double)iterations;
            output?.WriteLine($"{name} finished in {s.ElapsedMilliseconds}ms for {iterations} executions. Avg: {avgExecutionTime}ms. Target: {targetExecutionTime}ms.");

            if (avgExecutionTime > targetExecutionTime)
            {
                throw new BenchmarkFailedException();
            }
        }

        // ReSharper disable once InconsistentNaming
        public class BenchmarkFailedException : Exception
        {
            public BenchmarkFailedException()
            {
            }

            // ReSharper disable once UnusedMember.Global
            public BenchmarkFailedException(string message) : base(message)
            {
            }

            // ReSharper disable once UnusedMember.Global
            public BenchmarkFailedException(string message, Exception innerException) : base(message, innerException)
            {
            }

            // ReSharper disable once UnusedMember.Global
            protected BenchmarkFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
