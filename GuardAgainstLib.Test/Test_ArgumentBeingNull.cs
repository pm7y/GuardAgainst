using System;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingNull
    {
        [Theory]
        [InlineData(default(object), "myVal", "Argh!")]
        [InlineData(default(object), "myVal", "")]
        [InlineData(default(object), "myVal", "   ")]
        [InlineData(default(object), "myVal", null)]
        [InlineData(default(object), "", "")]
        [InlineData(default(object), null, "")]
        [InlineData(default(object), null, "   ")]
        [InlineData(default(object), "", null)]
        [InlineData(default(object), "   ", null)]
        [InlineData(default(object), null, null)]
        public void WhenArgumentIsNull_ShouldThrowArgumentNullException(object arg, string argName, string msg)
        {
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNull(arg, argName, msg);
            });

            ex.ParamName.ShouldBe(argName.NullIfWhitespace());
            ex.Message.ShouldContain(msg.NullIfWhitespace() ?? "Exception");
        }

        [Theory]
        [InlineData("", "myVal", "Argh!")]
        [InlineData("", "myVal", "")]
        [InlineData("", "myVal", "   ")]
        [InlineData("", "myVal", null)]
        [InlineData("", "", "")]
        [InlineData("", null, "")]
        [InlineData("", null, "   ")]
        [InlineData("", "", null)]
        [InlineData("", "   ", null)]
        [InlineData("", null, null)]
        public void WhenArgumentIsNotNull_ShouldNotThrowException(object arg, string argName, string msg)
        {
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNull(arg, argName, msg);
            });
        }
    }
}
