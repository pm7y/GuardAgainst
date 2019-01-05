using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingInvalid : TestBase
    {
        public Test_ArgumentBeingInvalid(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentExpressionIsFalseAndTrueMeansInvalid_ShouldNotThrow()
        {
            var myArgument = false;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(() => myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansInvalid);
            });
        }

        [Fact]
        public void WhenArgumentExpressionIsFalseAndTrueMeansValid_ShouldThrowArgumentException()
        {
            var myArgument = false;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(() => myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansValid);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentExpressionIsTrueAndTrueMeansInvalid_ShouldThrowArgumentException()
        {
            var myArgument = true;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(() => myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansInvalid);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentExpressionIsTrueAndTrueMeansValid_ShouldNotThrow()
        {
            var myArgument = true;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(() => myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansValid);
            });
        }

        [Fact]
        public void WhenArgumentIsFalseAndTrueMeansInvalid_ShouldNotThrow()
        {
            var myArgument = false;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansInvalid);
            });
        }

        [Fact]
        public void WhenArgumentIsFalseAndTrueMeansValid_ShouldThrowArgumentException()
        {
            var myArgument = false;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansValid);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsTrueAndTrueMeansInvalid_ShouldThrowArgumentException()
        {
            var myArgument = true;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansInvalid);
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsTrueAndTrueMeansValid_ShouldNotThrow()
        {
            var myArgument = true;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument), null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansValid);
            });
        }
    }
}
