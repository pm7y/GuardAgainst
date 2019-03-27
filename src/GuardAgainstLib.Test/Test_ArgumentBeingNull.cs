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
        public void WhenArgumentIsNotNull_ShouldNotThrow()
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
        public void WhenArgumentIsNotNull_ShouldNotBeSlow()
        {
            var myArgument = "Hello, World!";
            Should.CompleteIn(() =>
            {
                GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            }, TimeSpan.FromMilliseconds(1));
        }
    }
}
