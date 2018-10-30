using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingNullOrGreaterThanMaximum : TestBase
    {
        public Test_ArgumentBeingNullOrGreaterThanMaximum(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentExpressionIsEqualToMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(() => myArgument, "A", null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentExpressionIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = "B";
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(() => myArgument, "A", null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentExpressionIsLessThanMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(() => myArgument, "B", null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentExpressionIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(string);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(() => myArgument, "B", null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsEqualToMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "A", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = "B";
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "A", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsLessThanMaximum_ShouldNotThrow()
        {
            var myArgument = "A";
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "B", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(string);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "B", nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenExpressionMaximumValueIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = "A";
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(() => myArgument, null, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe("maximumAllowedValue");
            ex.Data.Count.ShouldBe(1);
        }

        [Fact]
        public void WhenMaximumValueIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = "A";
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, null, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe("maximumAllowedValue");
            ex.Data.Count.ShouldBe(1);
        }
    }
}
