using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestCanary
{
    [Fact]
    public void WhenEverythingIsAsItShouldBe_ThisTestShouldAlwaysPass()
    {
        true.ShouldBe(true);
    }
}
