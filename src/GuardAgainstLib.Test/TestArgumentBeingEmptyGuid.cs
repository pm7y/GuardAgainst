using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingEmptyGuid : TestBase
    {
        public TestArgumentBeingEmptyGuid(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsEmptyGuid_ShouldThrowArgumentException()
        {
            var myArgument = Guid.Empty;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument));
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }

        [Fact]
        public void WhenArgumentIsNotEmptyGuid_ShouldNotThrow()
        {
            var myArgument = new Guid("1e750e0a-f9be-4d31-a78e-590325cb7045");
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument));
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }
    }
}
