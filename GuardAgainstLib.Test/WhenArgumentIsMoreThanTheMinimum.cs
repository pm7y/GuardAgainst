//using System;
//using System.Collections.Generic;
//using Shouldly;
//using Xunit;

//namespace GuardAgainstLib.Test
//{
//    public class WhenArgumentIsMoreThanTheMinimum
//    {
//        [Theory]
//        [MemberData(nameof(Data))]
//        public void WhenArgumentIsMoreThanMinimum_ShouldNotThrowException<T>(T value, T minimumValue) where T : IComparable<T>
//        {
//            Should.NotThrow(
//                () => { GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue, nameof(value), "Argh!"); });
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void WhenArgumentIsMoreThanMinimum_AndErrorMessageIsNull_ShouldNotThrowException<T>(T value, T minimumValue)
//            where T : IComparable<T>
//        {
//            Should.NotThrow(() => { GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue, nameof(value)); });
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void WhenArgumentIsMoreThanMinimum_AndArgumentNameIsNull_ShouldNotThrowException<T>(T value, T minimumValue) where T : IComparable<T>
//        {
//            Should.NotThrow(() =>
//            {
//                GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue, exceptionMessage: "Argh!");
//            });
//        }

//        [Theory]
//        [MemberData(nameof(Data))]
//        public void WhenArgumentIsMoreThanMinimum_AndArgumentNameIsNull_AndErrorMessageIsNull_ShouldNotThrowException<T>(T value, T minimumValue) where T : IComparable<T>
//        {
//            Should.NotThrow(() => { GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue); });
//        }

//        public static IEnumerable<object[]> Data =>
//            new List<object[]>
//            {
//                new object[] { int.MaxValue, int.MinValue },
//                new object[] { long.MaxValue, long.MinValue },
//                new object[] { decimal.MaxValue, decimal.MinValue },
//                new object[] { double.MaxValue, double.MinValue },
//                new object[] { short.MaxValue, short.MinValue },
//                new object[] { float.MaxValue, float.MinValue },
//                new object[] { 'b', 'a'},
//                new object[] { DateTime.MaxValue, DateTime.MinValue },
//                new object[] { "b", "a" },
//            };
//    }
//}
