using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class Test_Canary : TestBase
    {
        public Test_Canary(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenEverythingIsAsItShouldBe_ThisTestShouldAlwaysPass()
        {
            true.ShouldBe(true);
        }
    }
}
