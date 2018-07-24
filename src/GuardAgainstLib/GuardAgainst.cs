using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GuardAgainstLib
{
    /// <summary>
    ///     A single class, containing static methods, to make your code more readable and to simplify argument validity
    ///     checking.
    ///     More information @ https://github.com/pmcilreavy/GuardAgainst
    /// </summary>
    [DebuggerNonUserCode]
    public static class GuardAgainst
    {
        private static string NullIfWhitespace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this) ? default(string) : @this;
        }

        private static void AddAdditionalDataToException(Exception ex,
                                                         Dictionary<object, object> additionalData)
        {
            if (ex?.Data == null || additionalData == null)
            {
                return;
            }

            foreach (var key in additionalData.Keys)
            {
                ex.Data.Add(key, additionalData[key]);
            }
        }

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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void ArgumentBeingNull<T>(T argumentValue,
                                                string argumentName = default(string),
                                                string exceptionMessage = default(string),
                                                Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : class
        {
            if (argumentValue != null)
            {
                return;
            }

            var ex = new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            AddAdditionalDataToException(ex, additionalData);
            throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingNullOrWhitespace(string argumentValue,
                                                         string argumentName = default(string),
                                                         string exceptionMessage = default(string),
                                                         Dictionary<object, object> additionalData = default(Dictionary<object, object>))
        {
            Exception ex = null;

            if (argumentValue == null)
            {
                ex = new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }
            else if (string.IsNullOrWhiteSpace(argumentValue))
            {
                ex = new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
            }

            if (ex != null)
            {
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingWhitespace(string argumentValue,
                                                   string argumentName = default(string),
                                                   string exceptionMessage = default(string),
                                                   Dictionary<object, object> additionalData = default(Dictionary<object, object>))
        {
            if (argumentValue == null)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(argumentValue))
            {
                var ex = new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingNullOrEmpty(string argumentValue,
                                                    string argumentName = default(string),
                                                    string exceptionMessage = default(string),
                                                    Dictionary<object, object> additionalData = default(Dictionary<object, object>))
        {
            Exception ex = null;

            if (argumentValue == null)
            {
                ex = new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }
            else if (string.IsNullOrEmpty(argumentValue))
            {
                ex = new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
            }

            if (ex != null)
            {
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingEmpty(string argumentValue,
                                              string argumentName = default(string),
                                              string exceptionMessage = default(string),
                                              Dictionary<object, object> additionalData = default(Dictionary<object, object>))
        {
            if (argumentValue == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(argumentValue))
            {
                var ex = new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingNullOrLessThanMinimum<T>(T argumentValue,
                                                                 T minimumAllowedValue,
                                                                 string argumentName = default(string),
                                                                 string exceptionMessage = default(string),
                                                                 Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : class, IComparable<T>
        {
            Exception ex = null;

            if (minimumAllowedValue == null)
            {
                ex = new ArgumentNullException(nameof(minimumAllowedValue));
            }
            else if (argumentValue == null)
            {
                ex = new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }
            else if (argumentValue.IsLessThan(minimumAllowedValue))
            {
                ex = new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }

            if (ex != null)
            {
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingLessThanMinimum<T>(T argumentValue,
                                                           T minimumAllowedValue,
                                                           string argumentName = default(string),
                                                           string exceptionMessage = default(string),
                                                           Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : class, IComparable<T>
        {
            if (argumentValue == null)
            {
                return;
            }

            Exception ex = null;

            if (minimumAllowedValue == null)
            {
                ex = new ArgumentNullException(nameof(minimumAllowedValue));
            }
            else if (argumentValue.IsLessThan(minimumAllowedValue))
            {
                ex = new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }

            if (ex != null)
            {
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingLessThanMinimumForValueType<T>(T argumentValue,
                                                                       T minimumAllowedValue,
                                                                       string argumentName = default(string),
                                                                       string exceptionMessage = default(string),
                                                                       Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : struct, IComparable<T>
        {
            if (argumentValue.IsLessThan(minimumAllowedValue))
            {
                var ex = new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingNullOrGreaterThanMaximum<T>(T argumentValue,
                                                                    T maximumAllowedValue,
                                                                    string argumentName = default(string),
                                                                    string exceptionMessage = default(string),
                                                                    Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : class, IComparable<T>
        {
            Exception ex = null;

            if (argumentValue == null)
            {
                ex = new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }
            else if (maximumAllowedValue == null)
            {
                ex = new ArgumentNullException(nameof(maximumAllowedValue));
            }
            else if (argumentValue.IsMoreThan(maximumAllowedValue))
            {
                ex = new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }

            if (ex != null)
            {
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingGreaterThanMaximum<T>(T argumentValue,
                                                              T maximumAllowedValue,
                                                              string argumentName = default(string),
                                                              string exceptionMessage = default(string),
                                                              Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : class, IComparable<T>
        {
            if (argumentValue == null)
            {
                return;
            }

            Exception ex = null;

            if (maximumAllowedValue == null)
            {
                ex = new ArgumentNullException(nameof(maximumAllowedValue));
            }
            else if (argumentValue.IsMoreThan(maximumAllowedValue))
            {
                ex = new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }

            if (ex != null)
            {
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingGreaterThanMaximumForValueType<T>(T argumentValue,
                                                                          T maximumAllowedValue,
                                                                          string argumentName = default(string),
                                                                          string exceptionMessage = default(string),
                                                                          Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : struct, IComparable<T>
        {
            if (argumentValue.IsMoreThan(maximumAllowedValue))
            {
                var ex = new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingNullOrOutOfRange<T>(T argumentValue,
                                                            T minimumAllowedValue,
                                                            T maximumAllowedValue,
                                                            string argumentName = default(string),
                                                            string exceptionMessage = default(string),
                                                            Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : class, IComparable<T>
        {
            Exception ex = null;

            if (argumentValue == null)
            {
                ex = new ArgumentNullException(argumentName.NullIfWhitespace(), exceptionMessage.NullIfWhitespace());
            }

            if (minimumAllowedValue == null)
            {
                ex = new ArgumentNullException(nameof(minimumAllowedValue));
            }
            else if (maximumAllowedValue == null)
            {
                ex = new ArgumentNullException(nameof(maximumAllowedValue));
            }
            else if (!argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue))
            {
                ex = new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }

            if (ex != null)
            {
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingOutOfRange<T>(T argumentValue,
                                                      T minimumAllowedValue,
                                                      T maximumAllowedValue,
                                                      string argumentName = default(string),
                                                      string exceptionMessage = default(string),
                                                      Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : class, IComparable<T>
        {
            Exception ex = null;

            if (argumentValue == null)
            {
                return;
            }

            if (minimumAllowedValue == null)
            {
                ex = new ArgumentNullException(nameof(minimumAllowedValue));
            }
            else if (maximumAllowedValue == null)
            {
                ex = new ArgumentNullException(nameof(maximumAllowedValue));
            }
            else if (!argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue))
            {
                ex = new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
            }

            if (ex != null)
            {
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void ArgumentBeingOutOfRangeForValueType<T>(T argumentValue,
                                                                  T minimumAllowedValue,
                                                                  T maximumAllowedValue,
                                                                  string argumentName = default(string),
                                                                  string exceptionMessage = default(string),
                                                                  Dictionary<object, object> additionalData = default(Dictionary<object, object>))
            where T : struct, IComparable<T>
        {
            if (!argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue))
            {
                var ex = new ArgumentOutOfRangeException(argumentName.NullIfWhitespace(), argumentValue, exceptionMessage.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
            }
        }

        private static bool IsInRange<T>(this T @this,
                                         T lowerBound,
                                         T upperBound)
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
                                          T lowerBound)
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingInvalid(bool condition,
                                                string argumentName = default(string),
                                                string exceptionMessage = default(string),
                                                Dictionary<object, object> additionalData = default(Dictionary<object, object>),
                                                ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (IsInvalid(condition, conditionMeaning))
            {
                var ex = new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="ArgumentException"></exception>
        public static void ArgumentBeingInvalid(Func<bool> condition,
                                                string argumentName = default(string),
                                                string exceptionMessage = default(string),
                                                Dictionary<object, object> additionalData = default(Dictionary<object, object>),
                                                ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (condition != null && IsInvalid(condition(), conditionMeaning))
            {
                var ex = new ArgumentException(exceptionMessage.NullIfWhitespace(), argumentName.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void InvalidOperation(bool condition,
                                            string exceptionMessage = default(string),
                                            Dictionary<object, object> additionalData = default(Dictionary<object, object>),
                                            ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (IsInvalid(condition, conditionMeaning))
            {
                var ex = new InvalidOperationException(exceptionMessage.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void InvalidOperation(Func<bool> condition,
                                            string exceptionMessage = default(string),
                                            Dictionary<object, object> additionalData = default(Dictionary<object, object>),
                                            ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (condition != null && IsInvalid(condition(), conditionMeaning))
            {
                var ex = new InvalidOperationException(exceptionMessage.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
        /// <param name="additionalData">Additional key/value data to add to the Data property of the exception.</param>
        /// <param name="conditionMeaning">
        ///     Can be used to change the polarity of the condition.
        ///     Defaults to TrueMeansInvalid. Is used in conjuction with the condition flag to determine whether or not to raise
        ///     the exception.
        /// </param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void InvalidOperation<T>(T argumentValue,
                                               Predicate<T> condition,
                                               string exceptionMessage = default(string),
                                               Dictionary<object, object> additionalData = default(Dictionary<object, object>),
                                               ConditionMeaning conditionMeaning = ConditionMeaning.TrueMeansInvalid)
        {
            if (condition != null && IsInvalid(condition(argumentValue), conditionMeaning))
            {
                var ex = new InvalidOperationException(exceptionMessage.NullIfWhitespace());
                AddAdditionalDataToException(ex, additionalData);
                throw ex;
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
            return condition && conditionMeaning == ConditionMeaning.TrueMeansValid || condition && conditionMeaning == ConditionMeaning.TrueMeansInvalid;
        }

        #endregion
    }
}