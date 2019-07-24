using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GuardAgainstLib
{
    /// <summary>
    /// A single class, containing useful guard clauses, that aims to simplify argument validity checking whilst
    /// making your code more readable. More information @ https://github.com/pmcilreavy/GuardAgainst
    /// </summary>
    public static class GuardAgainst
    {
        /// <summary>
        /// Guards against an argument being null. Will throw an
        /// <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception
        /// and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c> .</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument, Person person)
        /// {
        ///     GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingNull(person, nameof(person));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingNull<T>(T argumentValue,
                                                string argumentName = null,
                                                string exceptionMessage = null,
                                                IDictionary<object, object> additionalData = default)
            where T : class
        {
            if (!ReferenceEquals(argumentValue, null))
            {
                return;
            }

            var ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(), exceptionMessage.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Guards against an argument being null or whitespace. Will throw an
        /// <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        /// <see cref="ArgumentException">ArgumentException</see> if the argument is whitespace.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception
        /// and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c> .</exception>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is whitespace.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument, nameof(myArgument));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingNullOrWhitespace(string argumentValue,
                                                         string argumentName = null,
                                                         string exceptionMessage = null,
                                                         IDictionary<object, object> additionalData = default)
        {
            if (!string.IsNullOrWhiteSpace(argumentValue))
            {
                return;
            }

            if (ReferenceEquals(argumentValue, null))
            {
                var ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(), exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
            else
            {
                var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
        }

        /// <summary>
        /// Guards against an argument being whitespace. Will throw an
        /// <see cref="ArgumentException">ArgumentException</see> if the argument is whitespace.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception
        /// and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is whitespace.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingWhitespace(myArgument, nameof(myArgument));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingWhitespace(string argumentValue,
                                                   string argumentName = null,
                                                   string exceptionMessage = null,
                                                   IDictionary<object, object> additionalData = default)
        {
            if (ReferenceEquals(argumentValue, null) || !string.IsNullOrWhiteSpace(argumentValue))
            {
                return;
            }

            var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Guards against an argument being null or less than the specified minimum. Will throw an
        /// <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        /// <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is less than the specified
        /// minimum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Will be thrown when <c>argumentValue</c> is less than the specified
        /// minimum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrLessThanMinimum(myArgument, "A", nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingNullOrLessThanMinimum(dob, yearTwoThousand, nameof(dob));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingNullOrLessThanMinimum<T>(T argumentValue,
                                                                 T minimumAllowedValue,
                                                                 string argumentName = null,
                                                                 string exceptionMessage = null,
                                                                 IDictionary<object, object> additionalData = default)
            where T : class, IComparable<T>
        {
            if (ReferenceEquals(argumentValue, null))
            {
                var ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(), exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }

            if (argumentValue.IsLessThan(minimumAllowedValue))
            {
                var ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue, exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
        }

        /// <summary>
        /// Guards against an argument being less than the specified minimum. Will throw an
        /// <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is less than the specified
        /// minimum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Will be thrown when <c>argumentValue</c> is less than the specified
        /// minimum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(int myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingLessThanMinimum(dob, yearTwoThousand, nameof(dob));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingLessThanMinimum<T>(T argumentValue,
                                                           T minimumAllowedValue,
                                                           string argumentName = null,
                                                           string exceptionMessage = null,
                                                           IDictionary<object, object> additionalData = default)
            where T : IComparable<T>
        {
            if (ReferenceEquals(argumentValue, null))
            {
                return;
            }

            if (argumentValue.IsLessThan(minimumAllowedValue))
            {
                var ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue, exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
        }

        /// <summary>
        /// Guards against an argument being null or greater than the specified maximum. Will throw an
        /// <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        /// <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is greater than the specified
        /// maximum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Will be thrown when <c>argumentValue</c> is greater than the specified
        /// maximum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "Z", nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(dob, DateTime.now, nameof(dob));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingNullOrGreaterThanMaximum<T>(T argumentValue,
                                                                    T maximumAllowedValue,
                                                                    string argumentName = null,
                                                                    string exceptionMessage = null,
                                                                    IDictionary<object, object> additionalData = default)
            where T : class, IComparable<T>
        {
            if (ReferenceEquals(argumentValue, null))
            {
                var ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(), exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }

            if (argumentValue.IsMoreThan(maximumAllowedValue))
            {
                var ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue, exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
        }

        /// <summary>
        /// Guards against an argument being greater than the specified maximum. Will throw an
        /// <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is greater than the specified
        /// maximum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Will be thrown when <c>argumentValue</c> is greater than the specified
        /// maximum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(int myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, 100, nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingGreaterThanMaximum(dob, DateTime.Now, nameof(dob));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingGreaterThanMaximum<T>(T argumentValue,
                                                              T maximumAllowedValue,
                                                              string argumentName = null,
                                                              string exceptionMessage = null,
                                                              IDictionary<object, object> additionalData = default)
            where T : IComparable<T>
        {
            if (ReferenceEquals(argumentValue, null))
            {
                return;
            }

            if (argumentValue.IsMoreThan(maximumAllowedValue))
            {
                var ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue, exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
        }


        /// <summary>
        /// Guards against an argument being null or less than the specified minimum or greater than the specified
        /// maximum. Will throw an <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will
        /// throw an <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is less than the
        /// specified minimum or greater than the specified maximum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Will be thrown when <c>argumentValue</c> is less than the specified
        /// minimum or greater than the specified maximum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, "A", "Z", nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingNullOrOutOfRange(dob, yearTwoThousand, DateTime.Now, nameof(dob));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingNullOrOutOfRange<T>(T argumentValue,
                                                            T minimumAllowedValue,
                                                            T maximumAllowedValue,
                                                            string argumentName = null,
                                                            string exceptionMessage = null,
                                                            IDictionary<object, object> additionalData = default)
            where T : class, IComparable<T>
        {
            if (ReferenceEquals(argumentValue, null))
            {
                var ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(), exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }

            if (!argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue))
            {
                var ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue, exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
        }

        /// <summary>
        /// Guards against an argument being less than the specified minimum or greater than the specified maximum. Will
        /// throw an <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is less than the
        /// specified minimum or greater than the specified maximum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Will be thrown when <c>argumentValue</c> is less than the specified
        /// minimum or greater than the specified maximum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(int myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingOutOfRange(myArgument, 1, 100, nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingOutOfRange(dob, yearTwoThousand, DateTime.Now, nameof(dob));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingOutOfRange<T>(T argumentValue,
                                                      T minimumAllowedValue,
                                                      T maximumAllowedValue,
                                                      string argumentName = null,
                                                      string exceptionMessage = null,
                                                      IDictionary<object, object> additionalData = default)
            where T : IComparable<T>
        {
            if (ReferenceEquals(argumentValue, null))
            {
                return;
            }

            if (!argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue))
            {
                var ex = new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue, exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
        }

        /// <summary>
        /// Guards against an argument being invalid. The argument is invalid if the condition evaluates to <c>True</c> .
        /// Will throw an <see cref="ArgumentException">ArgumentException</see> .
        /// </summary>
        /// <param name="argumentValueInvalid">A boolean condition, which if <c>true</c> , indicates if the argument is invalid.</param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception
        /// and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValueInvalid</c> is evaluates to <c>true</c> .</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingInvalid(myArgument.StartsWith("!"), nameof(myArgument));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingInvalid(bool argumentValueInvalid,
                                                string argumentName = null,
                                                string exceptionMessage = null,
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
        /// Guards against an invalid operation. The operation is invalid if the condition evaluates to <c>True</c> . Will
        /// throw an <see cref="InvalidOperationException">InvalidOperationException</see> .
        /// </summary>
        /// <param name="operationInvalid">A boolean condition, which if <c>true</c> , indicates if the operation is invalid.</param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="InvalidOperationException">Will be thrown when <c>operationInvalid</c> is evaluates to <c>true</c> .</exception>
        /// <example>
        ///     <code>
        /// public void Start()
        /// {
        ///     GuardAgainst.OperationBeingInvalid(_started), nameof(myArgument));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void OperationBeingInvalid(bool operationInvalid,
                                                 string exceptionMessage = null,
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
        /// Guards against a DateTime argument being 'Unspecified'. Will throw an
        /// <see cref="ArgumentException">ArgumentException</see> when the 'Kind' is 'Unspecified'.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValueInvalid</c> is evaluates to <c>true</c> .</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(DateTime myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingUnspecifiedDateTime(myArgument, nameof(myArgument));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingUnspecifiedDateTime(DateTime argumentValue,
                                                            string argumentName = null,
                                                            string exceptionMessage = null,
                                                            IDictionary<object, object> additionalData = default)
        {
            if (argumentValue.Kind != DateTimeKind.Unspecified)
            {
                return;
            }

            var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Guards against an argument being null or an empty string. Will throw an
        /// <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        /// <see cref="ArgumentException">ArgumentException</see> if the argument is an empty string.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception
        /// and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c> .</exception>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is an empty string.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingNullOrEmpty(string argumentValue,
                                                    string argumentName = null,
                                                    string exceptionMessage = null,
                                                    IDictionary<object, object> additionalData = default)
        {
            if (!string.IsNullOrEmpty(argumentValue))
            {
                return;
            }

            if (ReferenceEquals(argumentValue, null))
            {
                var ex = new ArgumentNullException(argumentName.ToNullIfWhitespace(), exceptionMessage.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
            else
            {
                var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());

                ex.AddData(additionalData);
                throw ex;
            }
        }

        /// <summary>
        /// Guards against an argument being null or an empty enumerable. Will throw an
        /// <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        /// <see cref="ArgumentException">ArgumentException</see> if the argument is an empty enumerable.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception
        /// and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c> .</exception>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is an empty enumerable.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string[] myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingNullOrEmpty<T>(IEnumerable<T> argumentValue,
                                                       string argumentName = null,
                                                       string exceptionMessage = null,
                                                       IDictionary<object, object> additionalData = default)
        {
            if (ReferenceEquals(argumentValue, null))
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
        /// Guards against an argument being an empty string. Will throw an
        /// <see cref="ArgumentException">ArgumentException</see> if the argument is an empty string.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception
        /// and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is an empty string.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingEmpty(string argumentValue,
                                              string argumentName = null,
                                              string exceptionMessage = null,
                                              IDictionary<object, object> additionalData = default)
        {
            if (ReferenceEquals(argumentValue, null) || !string.IsNullOrEmpty(argumentValue))
            {
                return;
            }

            var ex = new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
            ex.AddData(additionalData);
            throw ex;
        }

        /// <summary>
        /// Guards against an argument being an empty enumerable. Will throw an
        /// <see cref="ArgumentException">ArgumentException</see> if the argument is an empty enumerable.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        /// (Optional) Name of the argument. If specified it will be included in the thrown exception
        /// and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        /// (Optional) Custom error message. A specific error message that can be used to describe
        /// the exception in more detail than the default message.
        /// </param>
        /// <param name="additionalData">(Optional) Additional information to add to the Data property of the thrown exception.</param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is an empty enumerable.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string[] myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument));
        /// 
        ///     // Remaining code omitted.
        /// }
        /// </code>
        /// </example>
        public static void ArgumentBeingEmpty<T>(IEnumerable<T> argumentValue,
                                                 string argumentName = null,
                                                 string exceptionMessage = null,
                                                 IDictionary<object, object> additionalData = default)
        {
            if (ReferenceEquals(argumentValue, default(IEnumerable<T>)) || argumentValue.Any())
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
            return string.IsNullOrWhiteSpace(@this) ? null : @this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void AddData(this Exception ex,
                                    IDictionary<object, object> additionalData)
        {
            if (additionalData is null || !additionalData.Any())
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