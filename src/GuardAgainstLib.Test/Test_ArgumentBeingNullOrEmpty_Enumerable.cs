using System;
using System.Collections.Generic;
using System.Linq;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingNullOrEmpty_Enumerable : TestBase
    {
        public Test_ArgumentBeingNullOrEmpty_Enumerable(ITestOutputHelper output) : base(output)
        {
        }
        
        [Fact]
        public void WhenArgumentIsEmpty_ShouldThrowArgumentException()
        {
            var myArgument = Enumerable.Empty<string>();
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsNotNullOrEmpty_ShouldNotThrow()
        {
            var myArgument = new[] { "blah" };
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(IEnumerable<string>);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsNotNullOrEmpty_ShouldNotBeSlow()
        {
            var myArgument = new[] { "blah" };
            Should.CompleteIn(() =>
            {
                GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            }, TimeSpan.FromMilliseconds(1));
        }
    }
}
