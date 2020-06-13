using System;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingEmptyEnumerable : TestBase
    {
        public TestArgumentBeingEmptyEnumerable(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEmptyEnumerable_ShouldThrowArgumentException()
        {
            var myArgument = Enumerable.Empty<int>();
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }

        [Fact]
        public void WhenArgumentIsNotNullOrEmptyString_ShouldNotThrow()
        {
            var myArgument = new[] { 1 };
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null);
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNullEnumerable_ShouldNotThrow()
        {
            var myArgument = default(int[]);
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null);
            });
            Assert.Equal(myArgument, result);
        }
    }
}
