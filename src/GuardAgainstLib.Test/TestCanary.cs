using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestCanary : TestBase
    {
        public TestCanary(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenEverythingIsAsItShouldBe_ThisTestShouldAlwaysPass()
        {
            true.ShouldBe(true);
        }
    }
}
