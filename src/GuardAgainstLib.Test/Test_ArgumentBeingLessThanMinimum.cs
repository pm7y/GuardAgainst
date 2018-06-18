using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace GuardAgainstLib.Test
{
    public class Test_ArgumentBeingLessThanMinimum
    {
        public static IEnumerable<object[]> DataWhereValueIsLessThanMinimumReferenceType =>
            new List<object[]>
            {
                new object[] { "a", "b", "myArg", "Err msg!" },
                new object[] { "a", "b", "myArg", null },
                new object[] { "a", "b", null, "Err msg!" },
                new object[] { "a", "b", null, null },
                new object[] { "a", "b", " ", " " },
                new object[] { "a", "b", "", "" }
            };

        public static IEnumerable<object[]> DataWhereValueIsLessThanMinimumValueType =>
            new List<object[]>
            {
                new object[] { int.MinValue, int.MaxValue, "myArg", "Err msg!" },
                new object[] { int.MinValue, int.MaxValue, "myArg", null },
                new object[] { int.MinValue, int.MaxValue, null, "Err msg!" },
                new object[] { int.MinValue, int.MaxValue, null, null },
                new object[] { int.MinValue, int.MaxValue, " ", " " },
                new object[] { int.MinValue, int.MaxValue, "", "" }
            };

        public static IEnumerable<object[]> DataWhereValueIsGreaterThanMinimumForReferenceType =>
            new List<object[]>
            {
                new object[] { "z", "a", "myArg", "Err msg!" },
                new object[] { "z", "a", "myArg", null },
                new object[] { "z", "a", null, "Err msg!" },
                new object[] { "z", "a", null, null },
                new object[] { "z", "a", " ", " " },
                new object[] { "z", "a", "", "" }
            };

        public static IEnumerable<object[]> DataWhereValueIsGreaterThanMinimumForValueType =>
            new List<object[]>
            {
                new object[] { int.MaxValue, int.MinValue, "myArg", "Err msg!" },
                new object[] { int.MaxValue, int.MinValue, "myArg", null },
                new object[] { int.MaxValue, int.MinValue, null, "Err msg!" },
                new object[] { int.MaxValue, int.MinValue, null, null },
                new object[] { int.MaxValue, int.MinValue, " ", " " },
                new object[] { int.MaxValue, int.MinValue, "", "" }
            };

        public static IEnumerable<object[]> DataWhereValueIsEqualToMinimumForReferenceType =>
            new List<object[]>
            {
                new object[] { "z", "z", "myArg", "Err msg!" },
                new object[] { "z", "z", "myArg", null },
                new object[] { "z", "z", null, "Err msg!" },
                new object[] { "z", "z", null, null },
                new object[] { "z", "z", " ", " " },
                new object[] { "z", "z", "", "" }
            };

        public static IEnumerable<object[]> DataWhereValueIsEqualToMinimumForValueType =>
            new List<object[]>
            {
                new object[] { int.MaxValue, int.MaxValue, "myArg", "Err msg!" },
                new object[] { int.MaxValue, int.MaxValue, "myArg", null },
                new object[] { int.MaxValue, int.MaxValue, null, "Err msg!" },
                new object[] { int.MaxValue, int.MaxValue, null, null },
                new object[] { int.MaxValue, int.MaxValue, " ", " " },
                new object[] { int.MaxValue, int.MaxValue, "", "" }
            };

        public static IEnumerable<object[]> DataWhereMinimumIsNullForReferenceType =>
            new List<object[]>
            {
                new object[] { "a", default(string), "myArg", "Err msg!" },
                new object[] { "a", default(string), "myArg", default(string) },
                new object[] { "a", default(string), default(string), "Err msg!" },
                new object[] { "a", default(string), default(string), default(string) }
            };

        public static IEnumerable<object[]> DataWhereArgumentIsNullForReferenceType =>
            new List<string[]>
            {
                new[] { default(string), "a", "myArg", "Err msg!" },
                new[] { default(string), "a", "myArg", default(string) },
                new[] { default(string), "a", default(string), "Err msg!" },
                new[] { default(string), "a", default(string), default(string) }
            };

        [Theory]
        [MemberData(nameof(DataWhereValueIsLessThanMinimumReferenceType))]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException_ForReferenceType<T>(T value,
                                                                                                             T minimumValue,
                                                                                                             string
                                                                                                                 argumentName,
                                                                                                             string
                                                                                                                 errorMessage)
            where T : class, IComparable<T>
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
        [MemberData(nameof(DataWhereValueIsLessThanMinimumValueType))]
        public void WhenArgumentIsLessThanMinimum_ShouldThrowArgumentOutOfRangeException_ForValueType<T>(T value,
                                                                                                         T minimumValue,
                                                                                                         string
                                                                                                             argumentName,
                                                                                                         string
                                                                                                             errorMessage)
            where T : struct, IComparable<T>
        {
            var ex = Should.Throw<ArgumentOutOfRangeException>(() =>
            {
                GuardAgainst
                    .ArgumentBeingLessThanMinimumForValueType(value,
                                                  minimumValue,
                                                  argumentName,
                                                  errorMessage);
            });

            ex.ActualValue.ShouldBe(value);
            ex.ParamName.ShouldBe(argumentName.NullIfWhitespace());
            ex.Message.ShouldContain(errorMessage.NullIfWhitespace() ?? "Exception");
        }

        [Theory]
        [MemberData(nameof(DataWhereValueIsGreaterThanMinimumForReferenceType))]
        [MemberData(nameof(DataWhereValueIsEqualToMinimumForReferenceType))]
        public void WhenArgumentIsGreaterThanOrEqualToMinimum_ShouldThrowNotException_ForReferenceType<T>(T value,
                                                                                                          T minimumValue,
                                                                                                          string
                                                                                                              argumentName,
                                                                                                          string
                                                                                                              errorMessage)
            where T : class, IComparable<T>
        {
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue,
                                                                          argumentName, errorMessage);
            });
        }

        [Theory]
        [MemberData(nameof(DataWhereValueIsGreaterThanMinimumForValueType))]
        [MemberData(nameof(DataWhereValueIsEqualToMinimumForValueType))]
        public void WhenArgumentIsGreaterThanOrEqualToMinimum_ShouldThrowNotException_ForValueType<T>(T value,
                                                                                                      T minimumValue,
                                                                                                      string
                                                                                                          argumentName,
                                                                                                      string
                                                                                                          errorMessage)
            where T : struct, IComparable<T>
        {
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimumForValueType(value, minimumValue, argumentName,
                                                          errorMessage);
            });
        }


        [Theory]
        [MemberData(nameof(DataWhereMinimumIsNullForReferenceType))]
        public void WhenMinimumValueIsNull_ShouldThrowArgumentNullException<T>(T value,
                                                                               T minimumValue,
                                                                               string argumentName,
                                                                               string errorMessage)
            where T : class, IComparable<T>
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
        [MemberData(nameof(DataWhereArgumentIsNullForReferenceType))]
        public void WhenArgumentIsNull_ShouldNotThrowException(string value,
                                                               string minimumValue,
                                                               string argumentName,
                                                               string errorMessage)
        {
            Should.NotThrow(() =>
            {
                GuardAgainst.ArgumentBeingLessThanMinimum(value, minimumValue,
                                                                          argumentName, errorMessage);
            });
        }
    }
}