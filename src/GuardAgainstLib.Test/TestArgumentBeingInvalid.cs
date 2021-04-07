using System;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test
{
    public class TestArgumentBeingInvalid : TestBase
    {
        public TestArgumentBeingInvalid(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void WhenArgumentIsFalse_ShouldNotThrow()
        {
            const bool myArgument = false;
            object result = null;
            Should.NotThrow(() =>
            {
                result = GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument));
            });
            Assert.NotNull(result);
            Assert.Equal(myArgument, result);
        }

        [Fact]
        public void WhenArgumentIsTrue_ShouldThrowArgumentException()
        {
            const bool myArgument = true;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument));
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }
        
        [Fact]
        public void WhenArgumentIsInvalidEnum_ShouldThrowArgumentException()
        {
            const TestEnum myArgument = TestEnum.Invalid;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, TestEnum.Invalid, nameof(myArgument));
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }
        
        
        [Fact]
        public void WhenArgumentIsInvalidEnum_AndInvalidEnumIsAssumed_ShouldThrowArgumentException()
        {
            const TestEnum myArgument = TestEnum.Invalid;
            var ex = Should.Throw<ArgumentException>(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument));
            });

            ex.ParamName.ShouldBe(nameof(myArgument));
        }
        
        
        [Fact]
        public void WhenArgumentIsValidEnum_ShouldNotThrow()
        {
            const TestEnum myArgument = TestEnum.Ok;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, TestEnum.Invalid, nameof(myArgument));
            });
        }
        
        
        [Fact]
        public void WhenArgumentIsValidEnum_AndInvalidEnumIsAssumed_ShouldNotThrow()
        {
            const TestEnum myArgument = TestEnum.Ok;
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingInvalid(myArgument, nameof(myArgument));
            });
        }
        

        private enum TestEnum : long
        {
            Invalid = 0,
            Ok = 1
        }
    }
}
