using System;
using System.Collections.Generic;
using System.Threading;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_OperationBeingInvalid : TestBase
    {
        public Test_OperationBeingInvalid(ITestOutputHelper output) : base(output)
        {

        }

        [Fact]
        public void WhenArgumentIsFalseAndTrueMeansInvalid_ShouldNotThrow()
        {
            var myArgument = false;
            Should.NotThrow(() =>
            {
                GuardAgainst.OperationBeingInvalid(myArgument, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansInvalid);
            });
        }

        [Fact]
        public void WhenArgumentIsFalseAndTrueMeansValid_ShouldThrowArgumentException()
        {
            var myArgument = false;
            var ex = Should.Throw<InvalidOperationException>(() =>
            {
                GuardAgainst.OperationBeingInvalid(myArgument, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansValid);
            });

            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsTrueAndTrueMeansInvalid_ShouldThrowArgumentException()
        {
            var myArgument = true;
            var ex = Should.Throw<InvalidOperationException>(() =>
            {
                GuardAgainst.OperationBeingInvalid(myArgument, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansInvalid);
            });

            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsTrueAndTrueMeansValid_ShouldNotThrow()
        {
            var myArgument = true;
            Should.NotThrow(() =>
            {
                GuardAgainst.OperationBeingInvalid(myArgument, null, new Dictionary<object, object>
                {
                    { "a", "1" }
                }, GuardAgainst.ConditionMeaning.TrueMeansValid);
            });
        }
    }
}
