using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingLessThanMinimumForValueType
    {
        [Fact]
        public void WhenArgumentExpressionIsEqualToMinimum_ShouldNotThrow()
        {
            var myArgument = 1;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(() => myArgument, 1, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentExpressionIsGreaterThanMinimum_ShouldNotThrow()
        {
            var myArgument = 2;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(() => myArgument, 1, null, new Dictionary<object, object>
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
                GuardAgainst.ArgumentBeingLessThanMinimum(() => myArgument, 2, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsEqualToMinimum_ShouldNotThrow()
        {
            var myArgument = 1;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                });
            });
        }

        [Fact]
        public void WhenArgumentIsGreaterThanMinimum_ShouldNotThrow()
        {
            var myArgument = 2;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument), null, new Dictionary<object, object>
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
                GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 2, nameof(myArgument), null, new Dictionary<object, object>
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