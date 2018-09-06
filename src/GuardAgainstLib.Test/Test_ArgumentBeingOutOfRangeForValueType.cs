using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingOutOfRangeForValueType
    {
        [Fact]
        public void WhenArgumentExpressionIsEqualToMaximum_ShouldNotThrow()
        {
            var myArgument = 4;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(() => myArgument, 2, 4, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentExpressionIsEqualToMinimum_ShouldNotThrow()
        {
            var myArgument = 2;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(() => myArgument, 2, 4, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentExpressionIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = 5;
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(() => myArgument, 2, 4, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentExpressionIsInRange_ShouldNotThrow()
        {
            var myArgument = 3;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(() => myArgument, 2, 4, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentExpressionIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = 1;
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(() => myArgument, 2, 4, null, new Dictionary<object, object>
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
            var myArgument = 4;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
        {
            var myArgument = 2;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = 5;
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsInRange_ShouldNotThrow()
        {
            var myArgument = 3;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException()
        {
            var myArgument = 1;
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingOutOfRange(myArgument, 2, 4, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}