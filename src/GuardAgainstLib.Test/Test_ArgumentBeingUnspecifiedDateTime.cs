using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingUnspecifiedDateTime : TestBase
    {
        public Test_ArgumentBeingUnspecifiedDateTime(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentValueIsLocal_ShouldNotThrow()
        {
            var myArgument = DateTime.UtcNow;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingUnspecifiedDateTime(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentValueIsUnspecified_ShouldThrowArgumentException()
        {
            var myArgument = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingUnspecifiedDateTime(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentValueIsUtc_ShouldNotThrow()
        {
            var myArgument = DateTime.UtcNow;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingUnspecifiedDateTime(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }
    }
}
