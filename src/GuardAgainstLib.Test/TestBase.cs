using System;
using Xunit.Abstractions;

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
