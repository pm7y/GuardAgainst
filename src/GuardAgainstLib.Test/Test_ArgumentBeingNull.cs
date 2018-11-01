using System;
using System.Collections.Generic;
using System.Diagnostics;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingNull : TestBase
    {
        public Test_ArgumentBeingNull(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenAdditionalData_ShouldThrowArgumentNullException()
        {
            var myArgument = default(object);
            var ex = Should.Throw<ArgumentNullException>(() => { GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument), null, null); });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(0);
        }


        [Fact]
        public void WhenArgumentExpressionIsNotNull_ShouldNotThrowException()
        {
            var myArgument = "Hello, World!";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNull(() => myArgument, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentExpressionIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(object);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNull(() => myArgument, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsNotNull_ShouldNotThrowException()
        {
            var myArgument = "Hello, World!";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(object);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenUsingAnExpression_PerformanceShouldNotBeTerribleButProbablyIs()
        {
            var iterations = 1000d;
            var sw = Stopwatch.StartNew();

            for (var i = 0; i < iterations; i++)
            {
                var myArgument = $"Hello, World! {i}";
                GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument));
            }

            sw.Stop();
            var variableMethod = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
            sw.Restart();

            for (var i = 0; i < iterations; i++)
            {
                var myArgument = $"Hello, World! {i}";
                GuardAgainst.ArgumentBeingNull(() => myArgument);
            }

            sw.Stop();
            var expressionMethod = sw.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));
            sw.Restart();

            var expressionMethodTimesSlower = expressionMethod / variableMethod;
            var expressionMethodTimesSlowerLimit = 500;

            Output.WriteLine("1 execution...");
            Output.WriteLine($"Variable way took  : ~ {Math.Round(variableMethod / iterations, 0, MidpointRounding.AwayFromZero):0000#} microseconds");
            Output.WriteLine($"Expression way took: ~ {Math.Round(expressionMethod / iterations, 0, MidpointRounding.AwayFromZero):0000#} microseconds");
            Output.WriteLine("");
            Output.WriteLine($"{iterations} executions...");
            Output.WriteLine($"Variable way took  :   {variableMethod:0000#} microseconds");
            Output.WriteLine($"Expression way took:   {expressionMethod:0000#} microseconds");
            Output.WriteLine("");
            Output.WriteLine($"Expression way is  : ~ {expressionMethodTimesSlower} times slower.");

            expressionMethodTimesSlower.ShouldBeLessThan(expressionMethodTimesSlowerLimit);
        }
    }
}
