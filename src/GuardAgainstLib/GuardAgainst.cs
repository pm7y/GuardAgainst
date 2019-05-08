using System;
using System.Collections.Generic;
using System.Linq;

namespace GuardAgainstLib
{
    /// <summary>
    /// A single class, containing useful guard clauses, that aims to simplify argument validity checking whilst making your code more readable.
    /// More information @ https://github.com/pmcilreavy/GuardAgainst
    /// </summary>
#if !DEBUGGABLE
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public static class GuardAgainst
    {
        #region ArgumentBeingNull

        /// <summary>
        /// Throws an ArgumentNullException if the argumentValue is null.
        /// </summary>
        /// <typeparam name="T" ></typeparam>
        /// <param name="argumentValue" >
        /// The argument value to check for null.
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

        #endregion ArgumentBeingNull

        #region ArgumentBeingNullOrWhitespace

        /// <summary>
        /// Throws an ArgumentNullException if the argumentValue is null.
        /// Throws an ArgumentException if the argumentValue is a whitespace string only.
        /// </summary>
        /// <param name="argumentValue" >
        /// The argument value to check for null or whitespace.
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

        #endregion ArgumentBeingNullOrWhitespace

        #region ArgumentBeingWhitespace

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

        #endregion ArgumentBeingWhitespace

        #region ArgumentBeingNullOrEmpty

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

        #endregion ArgumentBeingNullOrEmpty

        #region ArgumentBeingEmpty

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

        #endregion ArgumentBeingEmpty

        #region ArgumentBeingNullOrLessThanMinimum

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
            else if (argumentValue.CompareTo(minimumAllowedValue) < 0)
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

        #endregion ArgumentBeingNullOrLessThanMinimum

        #region ArgumentBeingLessThanMinimum

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
            if (argumentValue is null)
            {
                return;
            }

            Exception ex = null;

            if (minimumAllowedValue is null)
            {
                ex = new ArgumentNullException(nameof(minimumAllowedValue));
            }
            else if (argumentValue.CompareTo(minimumAllowedValue) < 0)
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

        #endregion ArgumentBeingLessThanMinimum

        #region ArgumentBeingNullOrGreaterThanMaximum

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
            else if (argumentValue.CompareTo(maximumAllowedValue) > 0)
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

        #endregion ArgumentBeingNullOrGreaterThanMaximum

        #region ArgumentBeingGreaterThanMaximum

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
            if (argumentValue is null)
            {
                return;
            }

            Exception ex = null;

            if (maximumAllowedValue is null)
            {
                ex = new ArgumentNullException(nameof(maximumAllowedValue));
            }
            else if (argumentValue.CompareTo(maximumAllowedValue) > 0)
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

        #endregion ArgumentBeingGreaterThanMaximum

        #region ArgumentBeingNullOrOutOfRange

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
            else if (!(argumentValue.CompareTo(minimumAllowedValue) >= 0 && argumentValue.CompareTo(maximumAllowedValue) <= 0))
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

        #endregion ArgumentBeingNullOrOutOfRange

        #region ArgumentBeingOutOfRange

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

            if (argumentValue is null)
            {
                return;
            }

            if (minimumAllowedValue is null)
            {
                ex = new ArgumentNullException(nameof(minimumAllowedValue));
            }
            else if (maximumAllowedValue is null)
            {
                ex = new ArgumentNullException(nameof(maximumAllowedValue));
            }
            else if (!(argumentValue.CompareTo(minimumAllowedValue) >= 0 && argumentValue.CompareTo(maximumAllowedValue) <= 0))
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

        #endregion ArgumentBeingOutOfRange

        #region ArgumentBeingInvalid

        /// <summary>
        /// Throws an ArgumentException if the argument is not valid.
        /// </summary>
        /// <param name="argumentValueInvalid" >
        /// Passing
        /// <c>
        /// true
        /// </c>
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

        #endregion ArgumentBeingInvalid

        #region OperationBeingInvalid

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

        #endregion OperationBeingInvalid

        #region ArgumentNotBeingUtcDateTime

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

        #endregion ArgumentNotBeingUtcDateTime

        #region private stuff

        private static string ToNullIfWhitespace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this) ? default : @this;
        }

        private static void AddData(this Exception @this,
                                    IDictionary<object, object> additionalExceptionData)
        {
            if (@this?.Data is null || additionalExceptionData is null || !additionalExceptionData.Any())
            {
                return;
            }

            foreach (var key in additionalExceptionData.Keys)
            {
                @this.Data.Add(key, additionalExceptionData[key]);
            }
        }

        #endregion private stuff
    }
}
