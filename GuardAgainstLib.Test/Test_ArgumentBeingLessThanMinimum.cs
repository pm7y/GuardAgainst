using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingLessThanMinimum
    {
        public static IEnumerable<object[]> DataWhereValueIsLessThanMinimum =>
            new List<object[]>
            {
                new object[] { int.MinValue, int.MaxValue, "myArg", "Err msg!" },
                new object[] { long.MinValue, long.MaxValue, "myArg", "Err msg!" },
                new object[] { decimal.MinValue, decimal.MaxValue, "myArg", "Err msg!" },
                new object[] { double.MinValue, double.MaxValue, "myArg", "Err msg!" },
                new object[] { short.MinValue, short.MaxValue, "myArg", "Err msg!" },
                new object[] { float.MinValue, float.MaxValue, "myArg", "Err msg!" },
                new object[] { 'a', 'b', "myArg", "Err msg!" },
                new object[] { DateTime.MinValue, DateTime.MaxValue, "myArg", "Err msg!" },
                new object[] { "a", "b", "myArg", "Err msg!" },

                new object[] { int.MinValue, int.MaxValue, "myArg", null },
                new object[] { long.MinValue, long.MaxValue, "myArg", null },
                new object[] { decimal.MinValue, decimal.MaxValue, "myArg", null },
                new object[] { double.MinValue, double.MaxValue, "myArg", null },
                new object[] { short.MinValue, short.MaxValue, "myArg", null },
                new object[] { float.MinValue, float.MaxValue, "myArg", null },
                new object[] { 'a', 'b', "myArg", null },
                new object[] { DateTime.MinValue, DateTime.MaxValue, "myArg", null },
                new object[] { "a", "b", "myArg", null },

                new object[] { int.MinValue, int.MaxValue, null, "Err msg!" },
                new object[] { long.MinValue, long.MaxValue, null, "Err msg!" },
                new object[] { decimal.MinValue, decimal.MaxValue, null, "Err msg!" },
                new object[] { double.MinValue, double.MaxValue, null, "Err msg!" },
                new object[] { short.MinValue, short.MaxValue, null, "Err msg!" },
                new object[] { float.MinValue, float.MaxValue, null, "Err msg!" },
                new object[] { 'a', 'b', null, "Err msg!" },
                new object[] { DateTime.MinValue, DateTime.MaxValue, null, "Err msg!" },
                new object[] { "a", "b", null, "Err msg!" },

                new object[] { int.MinValue, int.MaxValue, null, null },
                new object[] { long.MinValue, long.MaxValue, null, null },
                new object[] { decimal.MinValue, decimal.MaxValue, null, null },
                new object[] { double.MinValue, double.MaxValue, null, null },
                new object[] { short.MinValue, short.MaxValue, null, null },
                new object[] { float.MinValue, float.MaxValue, null, null },
                new object[] { 'a', 'b', null, null },
                new object[] { DateTime.MinValue, DateTime.MaxValue, null, null },
                new object[] { "a", "b", null, null },

                new object[] { int.MinValue, int.MaxValue, " ", " " },
                new object[] { long.MinValue, long.MaxValue, " ", " " },
                new object[] { decimal.MinValue, decimal.MaxValue, " ", " " },
                new object[] { double.MinValue, double.MaxValue, " ", " " },
                new object[] { short.MinValue, short.MaxValue, " ", " " },
                new object[] { float.MinValue, float.MaxValue, " ", " " },
                new object[] { 'a', 'b', " ", "Err msg!" },
                new object[] { DateTime.MinValue, DateTime.MaxValue, " ", " " },
                new object[] { "a", "b", " ", " " },

                new object[] { int.MinValue, int.MaxValue, "", "" },
                new object[] { long.MinValue, long.MaxValue, "", "" },
                new object[] { decimal.MinValue, decimal.MaxValue, "", "" },
                new object[] { double.MinValue, double.MaxValue, "", "" },
                new object[] { short.MinValue, short.MaxValue, "", "" },
                new object[] { float.MinValue, float.MaxValue, "", "" },
                new object[] { 'a', 'b', "", "Err msg!" },
                new object[] { DateTime.MinValue, DateTime.MaxValue, "", "" },
                new object[] { "a", "b", "", "" }
            };

        public static IEnumerable<object[]> DataWhereValueIsGreaterThanMinimum =>
            new List<object[]>
            {
                new object[] { int.MaxValue, int.MinValue, "myArg", "Err msg!" },
                new object[] { long.MaxValue, long.MaxValue, "myArg", "Err msg!" },
                new object[] { decimal.MaxValue, decimal.MaxValue, "myArg", "Err msg!" },
                new object[] { double.MaxValue, double.MaxValue, "myArg", "Err msg!" },
                new object[] { short.MaxValue, short.MaxValue, "myArg", "Err msg!" },
                new object[] { float.MaxValue, float.MaxValue, "myArg", "Err msg!" },
                new object[] { 'z', 'a', "myArg", "Err msg!" },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, "myArg", "Err msg!" },
                new object[] { "z", "a", "myArg", "Err msg!" },

                new object[] { int.MaxValue, int.MinValue, "myArg", null },
                new object[] { long.MaxValue, long.MaxValue, "myArg", null },
                new object[] { decimal.MaxValue, decimal.MaxValue, "myArg", null },
                new object[] { double.MaxValue, double.MaxValue, "myArg", null },
                new object[] { short.MaxValue, short.MaxValue, "myArg", null },
                new object[] { float.MaxValue, float.MaxValue, "myArg", null },
                new object[] { 'z', 'a', "myArg", null },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, "myArg", null },
                new object[] { "z", "a", "myArg", null },

                new object[] { int.MaxValue, int.MinValue, null, "Err msg!" },
                new object[] { long.MaxValue, long.MaxValue, null, "Err msg!" },
                new object[] { decimal.MaxValue, decimal.MaxValue, null, "Err msg!" },
                new object[] { double.MaxValue, double.MaxValue, null, "Err msg!" },
                new object[] { short.MaxValue, short.MaxValue, null, "Err msg!" },
                new object[] { float.MaxValue, float.MaxValue, null, "Err msg!" },
                new object[] { 'z', 'a', null, "Err msg!" },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, null, "Err msg!" },
                new object[] { "z", "a", null, "Err msg!" },

                new object[] { int.MaxValue, int.MinValue, null, null },
                new object[] { long.MaxValue, long.MaxValue, null, null },
                new object[] { decimal.MaxValue, decimal.MaxValue, null, null },
                new object[] { double.MaxValue, double.MaxValue, null, null },
                new object[] { short.MaxValue, short.MaxValue, null, null },
                new object[] { float.MaxValue, float.MaxValue, null, null },
                new object[] { 'z', 'a', null, null },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, null, null },
                new object[] { "z", "a", null, null },

                new object[] { int.MaxValue, int.MinValue, " ", " " },
                new object[] { long.MaxValue, long.MaxValue, " ", " " },
                new object[] { decimal.MaxValue, decimal.MaxValue, " ", " " },
                new object[] { double.MaxValue, double.MaxValue, " ", " " },
                new object[] { short.MaxValue, short.MaxValue, " ", " " },
                new object[] { float.MaxValue, float.MaxValue, " ", " " },
                new object[] { 'z', 'a', " ", "Err msg!" },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, " ", " " },
                new object[] { "z", "a", " ", " " },

                new object[] { int.MaxValue, int.MinValue, "", "" },
                new object[] { long.MaxValue, long.MaxValue, "", "" },
                new object[] { decimal.MaxValue, decimal.MaxValue, "", "" },
                new object[] { double.MaxValue, double.MaxValue, "", "" },
                new object[] { short.MaxValue, short.MaxValue, "", "" },
                new object[] { float.MaxValue, float.MaxValue, "", "" },
                new object[] { 'z', 'a', "", "Err msg!" },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, "", "" },
                new object[] { "z", "a", "", "" }
            };

        public static IEnumerable<object[]> DataWhereValueIsEqualToMinimum =>
            new List<object[]>
            {
                new object[] { int.MaxValue, int.MaxValue, "myArg", "Err msg!" },
                new object[] { long.MaxValue, long.MaxValue, "myArg", "Err msg!" },
                new object[] { decimal.MaxValue, decimal.MaxValue, "myArg", "Err msg!" },
                new object[] { double.MaxValue, double.MaxValue, "myArg", "Err msg!" },
                new object[] { short.MaxValue, short.MaxValue, "myArg", "Err msg!" },
                new object[] { float.MaxValue, float.MaxValue, "myArg", "Err msg!" },
                new object[] { 'z', 'z', "myArg", "Err msg!" },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, "myArg", "Err msg!" },
                new object[] { "z", "z", "myArg", "Err msg!" },

                new object[] { int.MaxValue, int.MaxValue, "myArg", null },
                new object[] { long.MaxValue, long.MaxValue, "myArg", null },
                new object[] { decimal.MaxValue, decimal.MaxValue, "myArg", null },
                new object[] { double.MaxValue, double.MaxValue, "myArg", null },
                new object[] { short.MaxValue, short.MaxValue, "myArg", null },
                new object[] { float.MaxValue, float.MaxValue, "myArg", null },
                new object[] { 'z', 'z', "myArg", null },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, "myArg", null },
                new object[] { "z", "z", "myArg", null },

                new object[] { int.MaxValue, int.MaxValue, null, "Err msg!" },
                new object[] { long.MaxValue, long.MaxValue, null, "Err msg!" },
                new object[] { decimal.MaxValue, decimal.MaxValue, null, "Err msg!" },
                new object[] { double.MaxValue, double.MaxValue, null, "Err msg!" },
                new object[] { short.MaxValue, short.MaxValue, null, "Err msg!" },
                new object[] { float.MaxValue, float.MaxValue, null, "Err msg!" },
                new object[] { 'z', 'z', null, "Err msg!" },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, null, "Err msg!" },
                new object[] { "z", "z", null, "Err msg!" },

                new object[] { int.MaxValue, int.MaxValue, null, null },
                new object[] { long.MaxValue, long.MaxValue, null, null },
                new object[] { decimal.MaxValue, decimal.MaxValue, null, null },
                new object[] { double.MaxValue, double.MaxValue, null, null },
                new object[] { short.MaxValue, short.MaxValue, null, null },
                new object[] { float.MaxValue, float.MaxValue, null, null },
                new object[] { 'z', 'z', null, null },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, null, null },
                new object[] { "z", "z", null, null },

                new object[] { int.MaxValue, int.MaxValue, " ", " " },
                new object[] { long.MaxValue, long.MaxValue, " ", " " },
                new object[] { decimal.MaxValue, decimal.MaxValue, " ", " " },
                new object[] { double.MaxValue, double.MaxValue, " ", " " },
                new object[] { short.MaxValue, short.MaxValue, " ", " " },
                new object[] { float.MaxValue, float.MaxValue, " ", " " },
                new object[] { 'z', 'z', " ", "Err msg!" },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, " ", " " },
                new object[] { "z", "z", " ", " " },

                new object[] { int.MaxValue, int.MaxValue, "", "" },
                new object[] { long.MaxValue, long.MaxValue, "", "" },
                new object[] { decimal.MaxValue, decimal.MaxValue, "", "" },
                new object[] { double.MaxValue, double.MaxValue, "", "" },
                new object[] { short.MaxValue, short.MaxValue, "", "" },
                new object[] { float.MaxValue, float.MaxValue, "", "" },
                new object[] { 'z', 'z', "", "Err msg!" },
                new object[] { DateTime.MaxValue, DateTime.MaxValue, "", "" },
                new object[] { "z", "z", "", "" }
            };

        public static IEnumerable<object[]> DataWhereMinimumIsNull =>
            new List<object[]>
            {
                new object[] { "a", default(string), "myArg", "Err msg!" },
                new object[] { "a", default(string), "myArg", default(string) },
                new object[] { "a", default(string), default(string), "Err msg!" },
                new object[] { "a", default(string), default(string), default(string) }
            };

        public static IEnumerable<object[]> DataWhereArgumentIsNull =>
            new List<string[]>
            {
                new[] { default(string), "a", "myArg", "Err msg!" },
                new[] { default(string), "a", "myArg", default(string) },
                new[] { default(string), "a", default(string), "Err msg!" },
                new[] { default(string), "a", default(string), default(string) }
            };

        [Theory]
        [MemberData(nameof(DataWhereValueIsLessThanMinimum))]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException<T>(T value,
                                                                                            T minimumValue,
                                                                                            string argumentName,
                                                                                            string errorMessage)
            where T : IComparable<T>
        {
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst
                    .ArgumentBeingLessThanMinimum(value,
                                                  minimumValue,
                                                  argumentName,
                                                  errorMessage);
            });

            ex.ActualValue.ShouldBe(value);
            ex.ParamName.ShouldBe(argumentName.NullIfWhitespace());
            ex.Message.ShouldContain(errorMessage.NullIfWhitespace() ?? "Exception");
        }

        [Theory]
        [MemberData(nameof(DataWhereValueIsGreaterThanMinimum))]
        [MemberData(nameof(DataWhereValueIsEqualToMinimum))]
        public void WhenArgumentIsGreaterThanOrEqualToMinimum_ShouldThrowNotException<T>(T value,
                                                                                         T minimumValue,
                                                                                         string argumentName,
                                                                                         string errorMessage)
            where T : IComparable<T>
        {
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue, argumentName,
                                                          errorMessage);
            });
        }

        [Theory]
        [MemberData(nameof(DataWhereMinimumIsNull))]
        public void WhenMinimumValueIsNull_ShouldThrowArgumentNullException<T>(T value,
                                                                               T minimumValue,
                                                                               string argumentName,
                                                                               string errorMessage)
            where T : IComparable<T>
        {
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(value,
                                                          minimumValue,
                                                          argumentName,
                                                          errorMessage);
            });

            ex.ParamName.ShouldBe("minimumAllowedValue");
        }

        [Theory]
        [MemberData(nameof(DataWhereArgumentIsNull))]
        public void WhenArgumentIsNull_ShouldNotThrowException(string value,
                                                               string minimumValue,
                                                               string argumentName,
                                                               string errorMessage)
        {
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue, argumentName,
                                                          errorMessage);
            });
        }
    }
}