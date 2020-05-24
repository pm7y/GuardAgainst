using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingEmpty_Enumerable : TestBase
    {
        public Test_ArgumentBeingEmpty_Enumerable(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEmptyEnumerable_ShouldThrowArgumentException()
        {
            var myArgument = Enumerable.Empty<int>();
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsNotNullOrEmptyString_ShouldNotThrow()
        {
            var myArgument = new[] {1};
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
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
                result = GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.Equal(myArgument, result);
        }
    }
}
