using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingNullOrLessThanMinimum
    {
        public static IEnumerable<object[]> DataWhereValueIsLessThanMinimum =>
            new List<string[]> { new[] { "a", "b", "myArg", "Err msg!" }, new[] { "a", "b", "myArg", null }, new[] { "a", "b", null, "Err msg!" }, new[] { "a", "b", null, null }, new[] { "a", "b", " ", " " }, new[] { "a", "b", "", "" } };

        public static IEnumerable<object[]> DataWhereValueIsGreaterThanMinimum =>
            new List<string[]> { new[] { "z", "a", "myArg", "Err msg!" }, new[] { "z", "a", "myArg", null }, new[] { "z", "a", null, "Err msg!" }, new[] { "z", "a", null, null }, new[] { "z", "a", " ", " " }, new[] { "z", "a", "", "" } };

        public static IEnumerable<object[]> DataWhereValueIsEqualToMinimum =>
            new List<string[]> { new[] { "z", "z", "myArg", "Err msg!" }, new[] { "z", "z", "myArg", null }, new[] { "z", "z", null, "Err msg!" }, new[] { "z", "z", null, null }, new[] { "z", "z", " ", " " }, new[] { "z", "z", "", "" } };

        public static IEnumerable<object[]> DataWhereMinimumIsNull =>
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
        [MemberData(nameof(DataWhereValueIsLessThanMinimum))]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException<T>(T value,
                                                                                            T minimumValue,
                                                                                            string argumentName,
                                                                                            string errorMessage)
            where T : class, IComparable<T>
        {
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrLessThanMinimum(value, minimumValue, argumentName, errorMessage);
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
            where T : class, IComparable<T>
        {
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingNullOrLessThanMinimum(value, minimumValue, argumentName, errorMessage);
            });
        }

        [Theory]
        [MemberData(nameof(DataWhereMinimumIsNull))]
        public void WhenMinimumValueIsNull_ShouldThrowArgumentNullException<T>(T value,
                                                                               T minimumValue,
                                                                               string argumentName,
                                                                               string errorMessage)
            where T : class, IComparable<T>
        {
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrLessThanMinimum(value, minimumValue, argumentName, errorMessage);
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
            var ex = Should.Throw<ArgumentNullException>(() =>
            {
                GuardAgainst.ArgumentBeingNullOrLessThanMinimum(value, minimumValue, argumentName, errorMessage);
            });

            ex.ParamName.ShouldBe(argumentName.NullIfWhitespace());
            ex.Message.ShouldContain(errorMessage.NullIfWhitespace() ?? "Exception");
        }
    }
}