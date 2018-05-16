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
            Should.Throw<ArgumentNullException>(() =>
            {
                const string arg = default(string);

                GuardAgainst.ArgumentBeingNull(arg, nameof(arg), "Argh!");
            });
        }

        [Fact]
        public void WhenArgumentIsNotNull_ShouldNotThrowException()
        {
            Should.NotThrow(() =>
            {
                const string arg = "blah";

                GuardAgainst.ArgumentBeingNull(arg, nameof(arg), "Argh!");
            });
        }

        [Fact]
        public void WhenArgumentIsEmpty_ShouldNotThrowException()
        {
            Should.NotThrow(() =>
            {
                const string arg = "";

                GuardAgainst.ArgumentBeingNull(arg, nameof(arg), "Argh!");
            });
        }

        [Fact]
        public void WhenArgumentIsWhitespace_ShouldNotThrowException()
        {
            Should.NotThrow(() =>
            {
                const string arg = "       ";

                GuardAgainst.ArgumentBeingNull(arg, nameof(arg), "Argh!");
            });
        }
    }
}
