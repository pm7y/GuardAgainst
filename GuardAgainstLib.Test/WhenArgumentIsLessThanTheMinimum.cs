using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class WhenArgumentIsLessThanTheMinimum
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowException<T>(T value, T minimumValue) where T : IComparable<T>
        {
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue, nameof(value), "Argh!");
            });

            ex.Message.ShouldContain("Argh!");
            ex.ActualValue.ShouldBe(value);
            ex.ParamName.ShouldBe(nameof(value));
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void WhenArgumentIsLessThanMinimum_AndErrorMessageIsNull_ShouldThrowException<T>(T value, T minimumValue)
            where T : IComparable<T>
        {
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue, nameof(value));
            });

            ex.ActualValue.ShouldBe(value);
            ex.ParamName.ShouldBe(nameof(value));
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void WhenArgumentIsLessThanMinimum_AndArgumentNameIsNull_ShouldThrowException<T>(T value, T minimumValue) where T : IComparable<T>
        {
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue, exceptionMessage: "Argh!");
            });

            ex.Message.ShouldContain("Argh!");
            ex.ActualValue.ShouldBe(value);
            ex.ParamName.ShouldBeNull();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void WhenArgumentIsLessThanMinimum_AndArgumentNameIsNull_AndErrorMessageIsNull_ShouldThrowException<T>(T value, T minimumValue) where T : IComparable<T>
        {
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue);
            });

            ex.ActualValue.ShouldBe(value);
            ex.ParamName.ShouldBeNull();
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { int.MinValue, int.MaxValue },
                new object[] { long.MinValue, long.MaxValue },
                new object[] { decimal.MinValue, decimal.MaxValue },
                new object[] { double.MinValue, double.MaxValue },
                new object[] { short.MinValue, short.MaxValue },
                new object[] { float.MinValue, float.MaxValue },
                new object[] { 'a', 'b'},
                new object[] { DateTime.MinValue, DateTime.MaxValue },
                new object[] { "a", "b" },
            };
    }
}
