using Xunit.Abstractions;

// ReSharper disable InconsistentNaming

namespace GuardAgainstLib.Test
{
    public class TestBase
    {
        public TestBase(ITestOutputHelper output)
        {
            Output = output;
        }

        protected ITestOutputHelper Output { get; }
    }
}
