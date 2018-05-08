using System;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class WhenArgumentIsNull
    {
        [Fact]
        public void WhenArgumentIsNull_ShouldThrowException()
        {
            Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                const string minimum = "b";
                const string arg = "a";

                GuardAgainst.ArgumentBeingLessThanMinimum(arg, minimum, nameof(arg), "Argh!");
            });
        }

        [Fact]
        public void WhenMinimumIsNull_ShouldNotThrowException()
        {
            Should.NotThrow(() =>
            {
                const string minimum = default(string);
                const string arg = "a";
                
                GuardAgainst.ArgumentBeingLessThanMinimum(arg, minimum, nameof(arg), "Argh!");
            });
        }
    }
}
