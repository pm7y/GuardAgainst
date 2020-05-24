using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingEmpty_String : TestBase
    {
        public Test_ArgumentBeingEmpty_String(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEmptyString_ShouldThrowArgumentException()
        {
            var myArgument = "";
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }

        [Fact]
        public void WhenArgumentIsNotNullOrEmptyString_ShouldNotThrow()
        {
            var myArgument = " blah ";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNullString_ShouldNotThrow()
        {
            var myArgument = default(string);
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.Equal(myArgument, result);
        }
    }
}
