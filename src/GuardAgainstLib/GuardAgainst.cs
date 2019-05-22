using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// ReSharper disable InconsistentNaming
namespace GuardAgainstLib
{
    /// <summary>
    /// A single class, containing useful guard clauses, that aims to simplify argument validity checking whilst making your code more readable.
    /// More information @ https://github.com/pmcilreavy/GuardAgainst
    /// </summary>
    public static class GuardAgainst
    {
        /// <summary>
        /// Guards against an argument being null. Will throw an <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue" >
        /// The argument value to guard.
        /// </param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">
        /// (Optional) Additional information to add to the Data property of the thrown exception.
        /// </param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c>.</exception>
        /// <example>
        /// <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument));
        ///
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingNull<T>(T argumentValue,
                                                string argumentName = default,
                                                string exceptionMessage = default,
                                                IDictionary<object, object> additionalData = default)
            where T : class
        {
            if (argumentValue != null)
            {
                return;
            }

            var ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                                               exceptionMessage.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Guards against an argument being null or whitespace.
        /// Will throw an <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null.
        /// Will throw an <see cref="ArgumentException">ArgumentException</see> if the argument is whitespace.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to guard.
        /// </param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">
        /// (Optional) Additional information to add to the Data property of the thrown exception.
        /// </param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is whitespace.</exception>
        /// <example>
        /// <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument, nameof(myArgument));
        ///
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingNullOrWhitespace(string argumentValue,
                                                         string argumentName = default,
                                                         string exceptionMessage = default,
                                                         IDictionary<object, object> additionalData = default)
        {
            if (!string.IsNullOrWhiteSpace(argumentValue))
            {
                return;
            }

            Exception ex;

            if (argumentValue is null)
            {
                ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                                               exceptionMessage.ToNullIfWhitespace());
            }
            else
            {
                ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            }

            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentException if the argumentValue is a whitespace string only.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for whitespace.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentException" ></exception>
        public static void ArgumentBeingWhitespace(string argumentValue,
                                                   string argumentName = default,
                                                   string exceptionMessage = default,
                                                   IDictionary<object, object> additionalData = default)
        {
            if (argumentValue is null ||
                !string.IsNullOrWhiteSpace(argumentValue))
            {
                return;
            }

            var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentNullException if the argumentValue is null.
        /// Throws an ArgumentOutOfRangeException if the argumentValue is less than the allowed minimum value.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for null or if less than minimum.
        /// </param>
        /// <param name="minimumAllowedValue" >
        /// The minimum allowed value.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentNullException" ></exception>
        /// <exception cref="ArgumentOutOfRangeException" ></exception>
        public static void ArgumentBeingNullOrLessThanMinimum<T>(T argumentValue,
                                                                 T minimumAllowedValue,
                                                                 string argumentName = default,
                                                                 string exceptionMessage = default,
                                                                 IDictionary<object, object> additionalData = default)
            where T : class, IComparable<T>
        {
            Exception ex = null;

            if (argumentValue is null)
            {
                ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                                               exceptionMessage.ToNullIfWhitespace());
            }
            else if (minimumAllowedValue is null)
            {
                ex = new ArgumentNullException(nameof(minimumAllowedValue));
            }
            else if (argumentValue.IsLessThan(minimumAllowedValue))
            {
                ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue,
                                                     exceptionMessage.ToNullIfWhitespace());
            }

            if (ex is null)
            {
                return;
            }

            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException if the argumentValue is less than the allowed minimum value.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check if less than minimum.
        /// </param>
        /// <param name="minimumAllowedValue" >
        /// The minimum allowed value.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentNullException" ></exception>
        /// <exception cref="ArgumentOutOfRangeException" ></exception>
        public static void ArgumentBeingLessThanMinimum<T>(T argumentValue,
                                                           T minimumAllowedValue,
                                                           string argumentName = default,
                                                           string exceptionMessage = default,
                                                           IDictionary<object, object> additionalData = default)
            where T : IComparable<T>
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
                ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(),
                                                     argumentValue,
                                                     exceptionMessage.ToNullIfWhitespace());
            }

            if (ex is null)
            {
                return;
            }

            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentNullException if the argumentValue is null.
        /// Throws an ArgumentOutOfRangeException if the argumentValue is greater than the allowed maximum value.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for null or if greater than maximum.
        /// </param>
        /// <param name="maximumAllowedValue" >
        /// The maximum allowed value.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentNullException" ></exception>
        /// <exception cref="ArgumentOutOfRangeException" ></exception>
        public static void ArgumentBeingNullOrGreaterThanMaximum<T>(T argumentValue,
                                                                    T maximumAllowedValue,
                                                                    string argumentName = default,
                                                                    string exceptionMessage = default,
                                                                    IDictionary<object, object> additionalData = default)
            where T : class, IComparable<T>
        {
            Exception ex = null;

            if (argumentValue is null)
            {
                ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                                               exceptionMessage.ToNullIfWhitespace());
            }
            else if (maximumAllowedValue is null)
            {
                ex = new ArgumentNullException(nameof(maximumAllowedValue));
            }
            else if (argumentValue.IsMoreThan(maximumAllowedValue))
            {
                ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue,
                                                     exceptionMessage.ToNullIfWhitespace());
            }

            if (ex is null)
            {
                return;
            }

            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException if the argumentValue is greater than the allowed maximum value.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check if greater than maximum.
        /// </param>
        /// <param name="maximumAllowedValue" >
        /// The maximum allowed value.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentNullException" ></exception>
        /// <exception cref="ArgumentOutOfRangeException" ></exception>
        public static void ArgumentBeingGreaterThanMaximum<T>(T argumentValue,
                                                              T maximumAllowedValue,
                                                              string argumentName = default,
                                                              string exceptionMessage = default,
                                                              IDictionary<object, object> additionalData = default)
            where T : IComparable<T>
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
                ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue,
                                                     exceptionMessage.ToNullIfWhitespace());
            }

            if (ex is null)
            {
                return;
            }

            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentNullException if the argumentValue is null.
        /// Throws an ArgumentOutOfRangeException if the argumentValue is less than the allowed minimum value.
        /// Throws an ArgumentOutOfRangeException if the argumentValue is greater than the allowed maximum value.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for null or if out of range.
        /// </param>
        /// <param name="minimumAllowedValue" >
        /// The minimum allowed value.
        /// </param>
        /// <param name="maximumAllowedValue" >
        /// The maximum allowed value.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentNullException" ></exception>
        /// <exception cref="ArgumentOutOfRangeException" ></exception>
        public static void ArgumentBeingNullOrOutOfRange<T>(T argumentValue,
                                                            T minimumAllowedValue,
                                                            T maximumAllowedValue,
                                                            string argumentName = default,
                                                            string exceptionMessage = default,
                                                            IDictionary<object, object> additionalData = default)
            where T : class, IComparable<T>
        {
            Exception ex = null;

            if (argumentValue is null)
            {
                ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                                               exceptionMessage.ToNullIfWhitespace());
            }
            else if (minimumAllowedValue is null)
            {
                ex = new ArgumentNullException(nameof(minimumAllowedValue));
            }
            else if (maximumAllowedValue is null)
            {
                ex = new ArgumentNullException(nameof(maximumAllowedValue));
            }
            else if (!argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue))
            {
                ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(),
                                                     argumentValue,
                                                     exceptionMessage.ToNullIfWhitespace());
            }

            if (ex is null)
            {
                return;
            }

            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentOutOfRangeException if the argumentValue is less than the allowed minimum value.
        /// Throws an ArgumentOutOfRangeException if the argumentValue is greater than the allowed maximum value.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for null or if out of range.
        /// </param>
        /// <param name="minimumAllowedValue" >
        /// The minimum allowed value.
        /// </param>
        /// <param name="maximumAllowedValue" >
        /// The maximum allowed value.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentNullException" ></exception>
        /// <exception cref="ArgumentOutOfRangeException" ></exception>
        public static void ArgumentBeingOutOfRange<T>(T argumentValue,
                                                      T minimumAllowedValue,
                                                      T maximumAllowedValue,
                                                      string argumentName = default,
                                                      string exceptionMessage = default,
                                                      IDictionary<object, object> additionalData = default)
            where T : IComparable<T>
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
                ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(),
                                                     argumentValue,
                                                     exceptionMessage.ToNullIfWhitespace());
            }

            if (ex is null)
            {
                return;
            }

            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentException if the argument is not valid.
        /// </summary>
        /// <param name="argumentValueInvalid" >Passing <c>true</c>
        /// indicates that the argument value is invalid.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentException" ></exception>
        public static void ArgumentBeingInvalid(bool argumentValueInvalid,
                                                string argumentName = default,
                                                string exceptionMessage = default,
                                                IDictionary<object, object> additionalData = default)
        {
            if (!argumentValueInvalid)
            {
                return;
            }

            var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an InvalidOperationException if the condition is not satisfied.
        /// </summary>
        /// <param name="operationInvalid" >
        /// Passing
        /// <c>
        /// true
        /// </c>
        /// indicates that the operation is invalid.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="InvalidOperationException" ></exception>
        public static void OperationBeingInvalid(bool operationInvalid,
                                                 string exceptionMessage = default,
                                                 IDictionary<object, object> additionalData = default)
        {
            if (!operationInvalid)
            {
                return;
            }

            var ex = new InvalidOperationException(exceptionMessage.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentException if the DateTime argument does not have a Utc Kind.
        /// </summary>
        /// <param name="argumentValue" >
        /// The DateTime object to test for UTC.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentException" ></exception>
        public static void ArgumentNotBeingUtcDateTime(DateTime argumentValue,
                                                       string argumentName = default,
                                                       string exceptionMessage = default,
                                                       IDictionary<object, object> additionalData = default)
        {
            if (argumentValue.Kind == DateTimeKind.Utc)
            {
                return;
            }

            var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentNullException if the argumentValue is null.
        /// Throws an ArgumentException if the argumentValue is an empty string only.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for null or empty.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentNullException" ></exception>
        /// <exception cref="ArgumentException" ></exception>
        public static void ArgumentBeingNullOrEmpty(string argumentValue,
                                                    string argumentName = default,
                                                    string exceptionMessage = default,
                                                    IDictionary<object, object> additionalData = default)
        {
            if (!string.IsNullOrEmpty(argumentValue))
            {
                return;
            }

            Exception ex;

            if (argumentValue is null)
            {
                ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                                               exceptionMessage.ToNullIfWhitespace());
            }
            else
            {
                ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            }

            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentException if the argumentValue contains no items.
        /// Throws an ArgumentNullException if the argumentValue is null.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for null or empty.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentNullException" ></exception>
        /// <exception cref="ArgumentException" ></exception>
        public static void ArgumentBeingNullOrEmpty<T>(IEnumerable<T> argumentValue,
                                                       string argumentName = default,
                                                       string exceptionMessage = default,
                                                       IDictionary<object, object> additionalData = default)
        {
            if (argumentValue is null)
            {
                var ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(), exceptionMessage.ToNullIfWhitespace());
                ex.AddData(additionalData);
                throw ex;
            }

            if (!argumentValue.Any())
            {
                var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
                ex.AddData(additionalData);
                throw ex;
            }
        }

        /// <summary>
        /// Throws an ArgumentException if the argumentValue is an empty string only.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for null or empty.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentException" ></exception>
        public static void ArgumentBeingEmpty(string argumentValue,
                                              string argumentName = default,
                                              string exceptionMessage = default,
                                              IDictionary<object, object> additionalData = default)
        {
            if (argumentValue is null ||
                !string.IsNullOrEmpty(argumentValue))
            {
                return;
            }

            var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Throws an ArgumentException if the argumentValue is empty only.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for empty.
        /// </param>
        /// <param name="argumentName" >
        /// Name of the argument. Can be optionally specified to be included in the raised exception.
        /// </param>
        /// <param name="exceptionMessage" >
        /// The exception message. An optional error message that describes the exception in more
        /// detail. If left null, the default .net message will be generated.
        /// </param>
        /// <param name="additionalData" >
        /// Additional key/value data to add to the Data property of the exception.
        /// </param>
        /// <exception cref="ArgumentException" ></exception>
        public static void ArgumentBeingEmpty<T>(IEnumerable<T> argumentValue,
                                                 string argumentName = default,
                                                 string exceptionMessage = default,
                                                 IDictionary<object, object> additionalData = default)
        {
            if (argumentValue is null ||
                argumentValue.Any())
            {
                return;
            }

            var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string ToNullIfWhitespace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this) ? default : @this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void AddData(this Exception ex,
                                    IDictionary<object, object> additionalData)
        {
            if (ex?.Data is null || additionalData is null || !additionalData.Any())
            {
                return;
            }

            foreach (var key in additionalData.Keys)
            {
                ex.Data.Add(key, additionalData[key]);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsStringInRange(this string @this,
                                            string lowerBound,
                                            string upperBound)
        {
            return string.CompareOrdinal(@this, lowerBound) >= 0 && string.CompareOrdinal(@this, upperBound) <= 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsInRange<T>(this T @this,
                                         T lowerBound,
                                         T upperBound)
            where T : IComparable<T>
        {
            if (typeof(T) == typeof(string))
            {
                return IsStringInRange(@this as string, lowerBound as string, upperBound as string);
            }

            return @this.CompareTo(lowerBound) >= 0 && @this.CompareTo(upperBound) <= 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsStringLessThan(this string @this,
                                             string lowerBound)
        {
            return string.CompareOrdinal(@this, lowerBound) < 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsLessThan<T>(this T @this,
                                          T lowerBound)
            where T : IComparable<T>
        {
            if (typeof(T) == typeof(string))
            {
                return IsStringLessThan(@this as string, lowerBound as string);
            }

            return @this.CompareTo(lowerBound) < 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsStringMoreThan(this string @this,
                                             string upperBound)
        {
            return string.CompareOrdinal(@this, upperBound) > 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsMoreThan<T>(this T @this,
                                          T upperBound)
            where T : IComparable<T>
        {
            if (typeof(T) == typeof(string))
            {
                return IsStringMoreThan(@this as string, upperBound as string);
            }

            return @this.CompareTo(upperBound) > 0;
        }
    }
}
