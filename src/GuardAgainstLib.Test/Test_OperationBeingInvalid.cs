using System;
using System.Collections.Generic;
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
        public void WhenArgumentIsFalse_ShouldNotThrow()
        {
            var myArgument = false;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.OperationBeingInvalid(myArgument, null, new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsTrue_ShouldThrowArgumentException()
        {
            var myArgument = true;
            var ex = Should.Throw<InvalidOperationException>(() =>
            {
                GuardAgainst.OperationBeingInvalid(myArgument, null, new Dictionary<object, object> {{"a", "1"}});
            });

            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}
