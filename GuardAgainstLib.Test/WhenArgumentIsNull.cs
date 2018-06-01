using System;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public static class Extensions
    {
        public static string NullIfWhitespace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this) ? null : @this;
        }
    }

    public class WhenArgumentIsNull
    {
        [Theory]
        [InlineData(default(object), "myVal", "Argh!")]
        [InlineData(default(object), "myVal", "")]
        [InlineData(default(object), "myVal", "   ")]
        [InlineData(default(object), "myVal", null)]
        [InlineData(default(object), "", null)]
        [InlineData(default(object), "   ", null)]
        [InlineData(default(object), null, null)]
        public void WhenArgumentIsNull_ShouldThrowException(object arg, string argName, string msg)
        {
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNull(arg, argName, msg);
            });

            ex.ParamName.ShouldBe(argName.NullIfWhitespace());
            ex.Message.ShouldContain(msg.NullIfWhitespace() ?? "Exception");
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
