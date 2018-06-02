using System.Reflection;

namespace GuardAgainstLib
{
    using System;
    using System.Diagnostics;

    /// <summary>
    ///     A single class, containing static methods, to make your code more readable and to simplify argument validity
    ///     checking.
    ///     More information @ https://github.com/pmcilreavy/GuardAgainst
    /// </summary>
    [DebuggerNonUserCode]
    public static class GuardAgainst
    {
        #region Null, Whitespace, Empty

        /// <summary>
        ///     Throws an ArgumentNullException if the argumentValue is null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentValue">The argument value to check for null.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ArgumentBeingNull<T>(T argumentValue,
                                                string argumentName = default(string),
                                                string exceptionMessage = default(string)) where T : class
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentNullException if the argumentValue is null.
        ///     Throws an ArgumentException if the argumentValue is a whitespace string only.
        /// </summary>
        /// <param name="argumentValue">The argument value to check for null or whitespace.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingNullOrWhitespace(string argumentValue,
                                                         string argumentName = default(string),
                                                         string exceptionMessage = default(string))
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }

            if (string.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentException if the argumentValue is a whitespace string only.
        /// </summary>
        /// <param name="argumentValue">The argument value to check for whitespace.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingWhitespace(string argumentValue,
                                                   string argumentName = default(string),
                                                   string exceptionMessage = default(string))
        {
            if (argumentValue == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(argumentValue))
            {
                throw new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentNullException if the argumentValue is null.
        ///     Throws an ArgumentException if the argumentValue is an empty string only.
        /// </summary>
        /// <param name="argumentValue">The argument value to check for null or empty.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingNullOrEmpty(string argumentValue,
                                                    string argumentName = default(string),
                                                    string exceptionMessage = default(string))
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }

            if (string.IsNullOrEmpty(argumentValue))
            {
                throw new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentException if the argumentValue is an empty string only.
        /// </summary>
        /// <param name="argumentValue">The argument value to check for null or empty.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingEmpty(string argumentValue,
                                              string argumentName = default(string),
                                              string exceptionMessage = default(string))
        {
            if (argumentValue == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(argumentValue))
            {
                throw new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
            }
        }

        #endregion Null, Whitespace, Empty

        #region Out of range

        /// <summary>
        ///     Throws an ArgumentNullException if the argumentValue is null.
        ///     Throws an ArgumentOutOfRangeException if the argumentValue is less than the allowed minimum value.
        /// </summary>
        /// <param name="argumentValue">The argument value to check for null or if less than minimum.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingNullOrLessThanMinimum<T>(T argumentValue,
                                                                 T minimumAllowedValue,
                                                                 string argumentName = default(string),
                                                                 string exceptionMessage = default(string)
        )
            where T : class, IComparable<T>
        {
            if (minimumAllowedValue == null)
            {
                throw new ArgumentNullException(nameof(minimumAllowedValue));
            }

            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }

            if (argumentValue.IsLessThan(minimumAllowedValue))
            {
                throw new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentOutOfRangeException if the argumentValue is less than the allowed minimum value.
        /// </summary>
        /// <param name="argumentValue">The argument value to check if less than minimum.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingLessThanMinimum<T>(T argumentValue,
                                                           T minimumAllowedValue,
                                                           string argumentName = default(string),
                                                           string exceptionMessage = default(string)
        )
            where T : IComparable<T>
        {
            if (argumentValue == null)
            {
                return;
            }

            if (minimumAllowedValue == null)
            {
                throw new ArgumentNullException(nameof(minimumAllowedValue));
            }

            if (argumentValue.IsLessThan(minimumAllowedValue))
            {
                throw new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentNullException if the argumentValue is null.
        ///     Throws an ArgumentOutOfRangeException if the argumentValue is greater than the allowed maximum value.
        /// </summary>
        /// <param name="argumentValue">The argument value to check for null or if greater than maximum.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingNullOrGreaterThanMaximum<T>(T argumentValue,
                                                                    T maximumAllowedValue,
                                                                    string argumentName = default(string),
                                                                    string exceptionMessage = default(string)
        )
            where T : class, IComparable<T>
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }

            if (maximumAllowedValue == null)
            {
                throw new ArgumentNullException(nameof(maximumAllowedValue));
            }

            if (argumentValue.IsMoreThan(maximumAllowedValue))
            {
                throw new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentOutOfRangeException if the argumentValue is greater than the allowed maximum value.
        /// </summary>
        /// <param name="argumentValue">The argument value to check if greater than maximum.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingGreaterThanMaximum<T>(T argumentValue,
                                                              T maximumAllowedValue,
                                                              string argumentName = default(string),
                                                              string exceptionMessage = default(string)
        )
            where T : IComparable<T>
        {
            if (argumentValue == null)
            {
                return;
            }

            if (maximumAllowedValue == null)
            {
                throw new ArgumentNullException(nameof(maximumAllowedValue));
            }

            if (argumentValue.IsMoreThan(maximumAllowedValue))
            {
                throw new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentNullException if the argumentValue is null.
        ///     Throws an ArgumentOutOfRangeException if the argumentValue is less than the allowed minimum value.
        ///     Throws an ArgumentOutOfRangeException if the argumentValue is greater than the allowed maximum value.
        /// </summary>
        /// <param name="argumentValue">The argument value to check for null or if out of range.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingNullOrOutOfRange<T>(T argumentValue,
                                                            T minimumAllowedValue,
                                                            T maximumAllowedValue,
                                                            string argumentName = default(string),
                                                            string exceptionMessage = default(string)
        )
            where T : class, IComparable<T>
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }

            if (minimumAllowedValue == null)
            {
                throw new ArgumentNullException(nameof(minimumAllowedValue));
            }

            if (maximumAllowedValue == null)
            {
                throw new ArgumentNullException(nameof(maximumAllowedValue));
            }

            if (!argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue))
            {
                throw new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentOutOfRangeException if the argumentValue is less than the allowed minimum value.
        ///     Throws an ArgumentOutOfRangeException if the argumentValue is greater than the allowed maximum value.
        /// </summary>
        /// <param name="argumentValue">The argument value to check for null or if out of range.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingOutOfRange<T>(T argumentValue,
                                                      T minimumAllowedValue,
                                                      T maximumAllowedValue,
                                                      string argumentName = default(string),
                                                      string exceptionMessage = default(string)
        )
            where T : IComparable<T>
        {
            if (argumentValue == null)
            {
                return;
            }

            if (minimumAllowedValue == null)
            {
                throw new ArgumentNullException(nameof(minimumAllowedValue));
            }

            if (maximumAllowedValue == null)
            {
                throw new ArgumentNullException(nameof(maximumAllowedValue));
            }

            if (!argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue))
            {
                throw new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }
        }

        private static bool IsInRange<T>(this T @this,
                                         T lowerBound,
                                         T upperBound
        )
            where T : IComparable<T>
        {
            return @this.CompareTo(lowerBound) >= 0 && @this.CompareTo(upperBound) <= 0;
        }

        private static bool IsLessThan<T>(this T @this,
                                          T lowerBound)
            where T : IComparable<T>
        {
            return @this.CompareTo(lowerBound) < 0;
        }

        private static bool IsMoreThan<T>(this T @this,
                                          T lowerBound
        )
            where T : IComparable<T>
        {
            return @this.CompareTo(lowerBound) > 0;
        }

        #endregion Out of range

        #region Invalid

        /// <summary>
        ///     Throws an ArgumentException if the argument is not valid.
        /// </summary>
        /// <param name="condition">
        ///     By default, <c>true</c> indicates that the argument value is invalid. This can be reversed by
        ///     setting conditionMeaning = ConditionMeaning.TrueMeansValid.
        /// </param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingInvalid(bool condition,
                                                string argumentName = default(string),
                                                string exceptionMessage = default(string),
                                                ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (IsInvalid(condition, conditionMeaning))
            {
                throw new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an ArgumentException if the argument is not valid.
        /// </summary>
        /// <param name="condition">
        ///     By default, <c>true</c> indicates that the argument value is invalid. This can be reversed by
        ///     setting conditionMeaning = ConditionMeaning.TrueMeansValid.
        /// </param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingInvalid(Func<bool> condition,
                                                string argumentName = default(string),
                                                string exceptionMessage = default(string),
                                                ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (condition != null && IsInvalid(condition(), conditionMeaning))
            {
                throw new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an InvalidOperationException if the condition is not met.
        /// </summary>
        /// <param name="condition">
        ///     By default, <c>true</c> indicates that the argument value is invalid. This can be reversed by
        ///     setting conditionMeaning = ConditionMeaning.TrueMeansValid.
        /// </param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void InvalidOperation(bool condition,
                                            string exceptionMessage = default(string),
                                            ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (IsInvalid(condition, conditionMeaning))
            {
                throw new InvalidOperationException(exceptionMessage.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an InvalidOperationException if the condition is not met.
        /// </summary>
        /// <param name="condition">
        ///     By default, <c>true</c> indicates that the argument value is invalid. This can be reversed by
        ///     setting conditionMeaning = ConditionMeaning.TrueMeansValid.
        /// </param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void InvalidOperation(Func<bool> condition,
                                            string exceptionMessage = default(string),
                                            ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (condition != null && IsInvalid(condition(), conditionMeaning))
            {
                throw new InvalidOperationException(exceptionMessage.NullIfWhitespace());
            }
        }

        /// <summary>
        ///     Throws an InvalidOperationException if the condition is not met.
        /// </summary>
        /// <param name="argumentValue">The argument value to check if invalid.</param>
        /// <param name="condition">
        ///     By default, <c>true</c> indicates that the argument value is invalid. This can be reversed by
        ///     setting conditionMeaning = ConditionMeaning.TrueMeansValid.
        /// </param>
        /// <param name="exceptionMessage">
        ///     The exception message. An optional error message that decribes the exception in more
        ///     detail.
        /// </param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void InvalidOperation<T>(T argumentValue,
                                               Predicate<T> condition,
                                               string exceptionMessage = default(string),
                                               ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (condition != null && IsInvalid(condition(argumentValue), conditionMeaning))
            {
                throw new InvalidOperationException(exceptionMessage.NullIfWhitespace());
            }
        }

        public enum ConditionMeaning
        {
            TrueMeansInvalid,
            TrueMeansValid
        }

        private static bool IsInvalid(bool condition,
                                      ConditionMeaning conditionMeaning)
        {
            return condition && conditionMeaning == ConditionMeaning.TrueMeansValid ||
                   condition && conditionMeaning == ConditionMeaning.TrueMeansInvalid;
        }

        #endregion

        private static string NullIfWhitespace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this) ? default(string) : @this;
        }
    }
}