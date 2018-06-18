using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_Canary
    {
        [Fact]
        public void WhenEverythingIsAsItShouldBe_ThisTestShouldAlwaysPass()
        {
            true.ShouldBe(true);
        }
    }
}