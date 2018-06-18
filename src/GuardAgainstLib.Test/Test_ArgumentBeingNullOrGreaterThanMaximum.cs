using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingNullOrGreaterThanMaximum
    {
        public static IEnumerable<object[]> DataWhereValueIsGreaterThanMaximum =>
            new List<string[]> { new[] { "b", "a", "myArg", "Err msg!" }, new[] { "b", "a", "myArg", null }, new[] { "b", "a", null, "Err msg!" }, new[] { "b", "a", null, null }, new[] { "b", "a", " ", " " }, new[] { "b", "a", "", "" } };

        public static IEnumerable<object[]> DataWhereValueIsLessThanMaximum =>
            new List<string[]> { new[] { "a", "z", "myArg", "Err msg!" }, new[] { "a", "z", "myArg", null }, new[] { "a", "z", null, "Err msg!" }, new[] { "a", "z", null, null }, new[] { "a", "z", " ", " " }, new[] { "a", "z", "", "" } };

        public static IEnumerable<object[]> DataWhereValueIsEqualToMaximum =>
            new List<string[]> { new[] { "z", "z", "myArg", "Err msg!" }, new[] { "z", "z", "myArg", null }, new[] { "z", "z", null, "Err msg!" }, new[] { "z", "z", null, null }, new[] { "z", "z", " ", " " }, new[] { "z", "z", "", "" } };

        public static IEnumerable<object[]> DataWhereMaximumIsNull =>
            new List<string[]>
            {
                new[] { "a", default(string), "myArg", "Err msg!" },
                new[] { "a", default(string), "myArg", default(string) },
                new[] { "a", default(string), default(string), "Err msg!" },
                new[] { "a", default(string), default(string), default(string) }
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
        [MemberData(nameof(DataWhereValueIsGreaterThanMaximum))]
        public void WhenArgumentIsGreaterThanMaximum_ShouldThrowArgumentOutOfRangeException<T>(T value,
                                                                                               T maximumValue,
                                                                                               string argumentName,
                                                                                               string errorMessage)
            where T : class, IComparable<T>
        {
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(value, maximumValue, argumentName, errorMessage);
            });

            ex.ActualValue.ShouldBe(value);
            ex.ParamName.ShouldBe(argumentName.NullIfWhitespace());
            ex.Message.ShouldContain(errorMessage.NullIfWhitespace() ?? "Exception");
        }

        [Theory]
        [MemberData(nameof(DataWhereValueIsLessThanMaximum))]
        [MemberData(nameof(DataWhereValueIsEqualToMaximum))]
        public void WhenArgumentIsLessThanOrEqualToMaximum_ShouldThrowNotException<T>(T value,
                                                                                      T maximumValue,
                                                                                      string argumentName,
                                                                                      string errorMessage)
            where T : class, IComparable<T>
        {
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(value, maximumValue, argumentName, errorMessage);
            });
        }

        [Theory]
        [MemberData(nameof(DataWhereMaximumIsNull))]
        public void WhenMaximumValueIsNull_ShouldThrowArgumentNullException<T>(T value,
                                                                               T maximumValue,
                                                                               string argumentName,
                                                                               string errorMessage)
            where T : class, IComparable<T>
        {
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(value, maximumValue, argumentName, errorMessage);
            });

            ex.ParamName.ShouldBe("maximumAllowedValue");
        }

        [Theory]
        [MemberData(nameof(DataWhereArgumentIsNull))]
        public void WhenArgumentIsNull_ShouldNotThrowException(string value,
                                                               string maximumValue,
                                                               string argumentName,
                                                               string errorMessage)
        {
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(value, maximumValue, argumentName, errorMessage);
            });

            ex.ParamName.ShouldBe(argumentName.NullIfWhitespace());
            ex.Message.ShouldContain(errorMessage.NullIfWhitespace() ?? "Exception");
        }
    }
}