using System;
using System.Collections.Generic;
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
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument));
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(0);
        }

        [Fact]
        public void WhenArgumentIsNotNull_ShouldNotThrow()
        {
            var myArgument = "Hello, World!";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(object);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}
