using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingNullOrEmpty_String : TestBase
    {
        public Test_ArgumentBeingNullOrEmpty_String(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEmpty_ShouldThrowArgumentException()
        {
            var myArgument = "";
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
        
        [Fact]
        public void WhenArgumentIsNotNullOrEmpty_ShouldNotThrow()
        {
            var myArgument = " blah ";
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException()
        {
            var myArgument = default(string);
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument), null,
                    new Dictionary<object, object> {{"a", "1"}});
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
            ex.Data.Count.ShouldBe(1);
            ex.Data["a"].ShouldBe("1");
        }
    }
}
