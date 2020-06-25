using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GuardAgainstLib
{
    /// <summary>
    ///     A single class, containing useful guard clauses, that aims to simplify argument validity checking whilst
    ///     making your code more readable. More information @ https://github.com/pmcilreavy/GuardAgainst
    /// </summary>
    public static partial class GuardAgainst
    {
        /// <summary>
        ///     Guards against an argument being null. Will throw an
        ///     <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        ///     (Optional) Name of the argument. If specified it will be included in the thrown exception
        ///     and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c> .</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument, Person person)
        /// {
        ///     GuardAgainst.ArgumentBeingNull(myArgument, nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingNull(person, nameof(person));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static T ArgumentBeingNull<T>(T argumentValue,
                                             string argumentName = null,
                                             string exceptionMessage = null)
            where T : class
        {
            return argumentValue ?? throw new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                exceptionMessage.ToNullIfWhitespace());
        }

        /// <summary>
        ///     Guards against an argument being null or whitespace. Will throw an
        ///     <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        ///     <see cref="ArgumentException">ArgumentException</see> if the argument is whitespace.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        ///     (Optional) Name of the argument. If specified it will be included in the thrown exception
        ///     and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c> .</exception>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is whitespace.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrWhitespace(myArgument, nameof(myArgument));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static string ArgumentBeingNullOrWhitespace(string argumentValue,
                                                           string argumentName = null,
                                                           string exceptionMessage = null)
        {
            if (!argumentValue.IsNullOrWhitespace())
            {
                return argumentValue;
            }

            _ = argumentValue ?? throw new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                exceptionMessage.ToNullIfWhitespace());

            throw new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
        }

        /// <summary>
        ///     Guards against an argument being whitespace. Will throw an
        ///     <see cref="ArgumentException">ArgumentException</see> if the argument is whitespace.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        ///     (Optional) Name of the argument. If specified it will be included in the thrown exception
        ///     and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is whitespace.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingWhitespace(myArgument, nameof(myArgument));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static string ArgumentBeingWhitespace(string argumentValue,
                                                     string argumentName = null,
                                                     string exceptionMessage = null)
        {
            return argumentValue.IsWhitespace()
                ? throw new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace())
                : argumentValue;
        }

        /// <summary>
        ///     Guards against an argument being null or less than the specified minimum. Will throw an
        ///     <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        ///     <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is less than the
        ///     specified
        ///     minimum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Will be thrown when <c>argumentValue</c> is less than the specified
        ///     minimum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrLessThanMinimum(myArgument, "A", nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingNullOrLessThanMinimum(dob, yearTwoThousand, nameof(dob));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static T ArgumentBeingNullOrLessThanMinimum<T>(T argumentValue,
                                                              T minimumAllowedValue,
                                                              string argumentName = null,
                                                              string exceptionMessage = null)
            where T : class, IComparable<T>
        {
            _ = argumentValue ?? throw new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                exceptionMessage.ToNullIfWhitespace());

            return argumentValue.IsLessThan(minimumAllowedValue)
                ? throw new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue,
                    exceptionMessage.ToNullIfWhitespace())
                : argumentValue;
        }

        /// <summary>
        ///     Guards against an argument being less than the specified minimum. Will throw an
        ///     <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is less than the
        ///     specified
        ///     minimum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Will be thrown when <c>argumentValue</c> is less than the specified
        ///     minimum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(int myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingLessThanMinimum(myArgument, 1, nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingLessThanMinimum(dob, yearTwoThousand, nameof(dob));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static T ArgumentBeingLessThanMinimum<T>(T argumentValue,
                                                        T minimumAllowedValue,
                                                        string argumentName = null,
                                                        string exceptionMessage = null)
            where T : IComparable<T>
        {
            return argumentValue.IsNull()
                ? default
                : argumentValue.IsLessThan(minimumAllowedValue)
                    ? throw new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue,
                        exceptionMessage.ToNullIfWhitespace())
                    : argumentValue;
        }

        /// <summary>
        ///     Guards against an argument being null or greater than the specified maximum. Will throw an
        ///     <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        ///     <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is greater than the
        ///     specified
        ///     maximum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Will be thrown when <c>argumentValue</c> is greater than the specified
        ///     maximum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(myArgument, "Z", nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum(dob, DateTime.now, nameof(dob));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static T ArgumentBeingNullOrGreaterThanMaximum<T>(T argumentValue,
                                                                 T maximumAllowedValue,
                                                                 string argumentName = null,
                                                                 string exceptionMessage = null)
            where T : class, IComparable<T>
        {
            _ = argumentValue ?? throw new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                exceptionMessage.ToNullIfWhitespace());

            return argumentValue.IsMoreThan(maximumAllowedValue)
                ? throw new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue,
                    exceptionMessage.ToNullIfWhitespace())
                : argumentValue;
        }

        /// <summary>
        ///     Guards against an argument being greater than the specified maximum. Will throw an
        ///     <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is greater than the
        ///     specified
        ///     maximum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Will be thrown when <c>argumentValue</c> is greater than the specified
        ///     maximum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(int myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingGreaterThanMaximum(myArgument, 100, nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingGreaterThanMaximum(dob, DateTime.Now, nameof(dob));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static T ArgumentBeingGreaterThanMaximum<T>(T argumentValue,
                                                           T maximumAllowedValue,
                                                           string argumentName = null,
                                                           string exceptionMessage = null)
            where T : IComparable<T>
        {
            return argumentValue.IsNull()
                ? default
                : argumentValue.IsMoreThan(maximumAllowedValue)
                    ? throw new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue,
                        exceptionMessage.ToNullIfWhitespace())
                    : argumentValue;
        }


        /// <summary>
        ///     Guards against an argument being null or less than the specified minimum or greater than the specified
        ///     maximum. Will throw an <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will
        ///     throw an <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is less than the
        ///     specified minimum or greater than the specified maximum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Will be thrown when <c>argumentValue</c> is less than the specified
        ///     minimum or greater than the specified maximum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrOutOfRange(myArgument, "A", "Z", nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingNullOrOutOfRange(dob, yearTwoThousand, DateTime.Now, nameof(dob));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static T ArgumentBeingNullOrOutOfRange<T>(T argumentValue,
                                                         T minimumAllowedValue,
                                                         T maximumAllowedValue,
                                                         string argumentName = null,
                                                         string exceptionMessage = null)
            where T : class, IComparable<T>
        {
            _ = argumentValue ??
                throw new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                    exceptionMessage.ToNullIfWhitespace());

            return argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue)
                ? argumentValue
                : throw new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue,
                    exceptionMessage.ToNullIfWhitespace());
        }

        /// <summary>
        ///     Guards against an argument being less than the specified minimum or greater than the specified maximum. Will
        ///     throw an <see cref="ArgumentOutOfRangeException">ArgumentOutOfRangeException</see> if the argument is less than the
        ///     specified minimum or greater than the specified maximum.
        /// </summary>
        /// <typeparam name="T">A reference type.</typeparam>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="minimumAllowedValue">The minimum allowed value.</param>
        /// <param name="maximumAllowedValue">The maximum allowed value.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Will be thrown when <c>argumentValue</c> is less than the specified
        ///     minimum or greater than the specified maximum.
        /// </exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(int myArgument, DateTime dob)
        /// {
        ///     GuardAgainst.ArgumentBeingOutOfRange(myArgument, 1, 100, nameof(myArgument));
        ///     GuardAgainst.ArgumentBeingOutOfRange(dob, yearTwoThousand, DateTime.Now, nameof(dob));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static T ArgumentBeingOutOfRange<T>(T argumentValue,
                                                   T minimumAllowedValue,
                                                   T maximumAllowedValue,
                                                   string argumentName = null,
                                                   string exceptionMessage = null)
            where T : IComparable<T>
        {
            return argumentValue.IsNull()
                ? default
                : argumentValue.IsInRange(minimumAllowedValue, maximumAllowedValue)
                    ? argumentValue
                    : throw new ArgumentOutOfRangeException(argumentName.ToNullIfWhitespace(), argumentValue,
                        exceptionMessage.ToNullIfWhitespace());
        }

        /// <summary>
        ///     Guards against an argument being invalid. The argument is invalid if the condition evaluates to <c>True</c> .
        ///     Will throw an <see cref="ArgumentException">ArgumentException</see> .
        /// </summary>
        /// <param name="argumentValueIsInvalid">A boolean condition, which if <c>true</c> , indicates if the argument is invalid.</param>
        /// <param name="argumentName">
        ///     (Optional) Name of the argument. If specified it will be included in the thrown exception
        ///     and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValueInvalid</c> is evaluates to <c>true</c> .</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingInvalid(myArgument.StartsWith("!"));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static bool ArgumentBeingInvalid(bool argumentValueIsInvalid,
                                                string argumentName = null,
                                                string exceptionMessage = null)
        {
            return argumentValueIsInvalid
                ? throw new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace())
                : false;
        }

        /// <summary>
        ///     Guards against an invalid operation. The operation is invalid if the condition evaluates to <c>True</c> . Will
        ///     throw an <see cref="InvalidOperationException">InvalidOperationException</see> .
        /// </summary>
        /// <param name="operationIsInvalid">A boolean condition, which if <c>true</c> , indicates if the operation is invalid.</param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="InvalidOperationException">Will be thrown when <c>operationInvalid</c> is evaluates to <c>true</c> .</exception>
        /// <example>
        ///     <code>
        /// public void Start()
        /// {
        ///     GuardAgainst.OperationBeingInvalid(_started));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static bool OperationBeingInvalid(bool operationIsInvalid,
                                                 string exceptionMessage = null)
        {
            return operationIsInvalid
                ? throw new InvalidOperationException(exceptionMessage.ToNullIfWhitespace())
                : false;
        }

        /// <summary>
        ///     Guards against a DateTime argument being 'Unspecified'. Will throw an
        ///     <see cref="ArgumentException">ArgumentException</see> when the 'Kind' is 'Unspecified'.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">Name of the argument. Can be optionally specified to be included in the raised exception.</param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValueInvalid</c> is evaluates to <c>true</c> .</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(DateTime myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingUnspecifiedDateTime(myArgument, nameof(myArgument));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static DateTime ArgumentBeingUnspecifiedDateTime(DateTime argumentValue,
                                                                string argumentName = null,
                                                                string exceptionMessage = null)
        {
            return argumentValue.Kind != DateTimeKind.Unspecified
                ? argumentValue
                : throw new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
        }

        /// <summary>
        ///     Guards against an argument being null or an empty string. Will throw an
        ///     <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        ///     <see cref="ArgumentException">ArgumentException</see> if the argument is an empty string.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        ///     (Optional) Name of the argument. If specified it will be included in the thrown exception
        ///     and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c> .</exception>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is an empty string.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static string ArgumentBeingNullOrEmpty(string argumentValue,
                                                      string argumentName = null,
                                                      string exceptionMessage = null)
        {
            if (!argumentValue.IsNullOrEmpty())
            {
                return argumentValue;
            }

            _ = argumentValue ?? throw new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                exceptionMessage.ToNullIfWhitespace());

            throw new ArgumentException(exceptionMessage.ToNullIfWhitespace(),
                argumentName.ToNullIfWhitespace());
        }

        /// <summary>
        ///     Guards against an argument being null or an empty enumerable. Will throw an
        ///     <see cref="ArgumentNullException">ArgumentNullException</see> if the argument is null. Will throw an
        ///     <see cref="ArgumentException">ArgumentException</see> if the argument is an empty enumerable.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        ///     (Optional) Name of the argument. If specified it will be included in the thrown exception
        ///     and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentNullException">Will be thrown when <c>argumentValue</c> is <c>null</c> .</exception>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is an empty enumerable.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string[] myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static IEnumerable<T> ArgumentBeingNullOrEmpty<T>(IEnumerable<T> argumentValue,
                                                                 string argumentName = null,
                                                                 string exceptionMessage = null)
        {
            _ = argumentValue ?? throw new ArgumentNullException(argumentName.ToNullIfWhitespace(),
                exceptionMessage.ToNullIfWhitespace());

            return argumentValue.Any()
                ? argumentValue
                : throw new ArgumentException(exceptionMessage.ToNullIfWhitespace(),
                    argumentName.ToNullIfWhitespace());
        }

        /// <summary>
        ///     Guards against an argument being an empty string. Will throw an
        ///     <see cref="ArgumentException">ArgumentException</see> if the argument is an empty string.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        ///     (Optional) Name of the argument. If specified it will be included in the thrown exception
        ///     and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is an empty string.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static string ArgumentBeingEmpty(string argumentValue,
                                                string argumentName = null,
                                                string exceptionMessage = null)
        {
            return argumentValue.IsEmpty()
                ? throw new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace())
                : argumentValue;
        }

        /// <summary>
        ///     Guards against an argument being an empty Guid. Will throw an
        ///     <see cref="ArgumentException">ArgumentException</see> if the argument is an empty Guid.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        ///     (Optional) Name of the argument. If specified it will be included in the thrown exception
        ///     and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is an empty Guid.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(Guid myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingEmpty(myArgument, nameof(myArgument));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static Guid ArgumentBeingEmpty(Guid argumentValue,
                                              string argumentName = null,
                                              string exceptionMessage = null)
        {
            return argumentValue == Guid.Empty
                ? throw new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace())
                : argumentValue;
        }

        /// <summary>
        ///     Guards against an argument being an empty enumerable. Will throw an
        ///     <see cref="ArgumentException">ArgumentException</see> if the argument is an empty enumerable.
        /// </summary>
        /// <param name="argumentValue">The argument value to guard.</param>
        /// <param name="argumentName">
        ///     (Optional) Name of the argument. If specified it will be included in the thrown exception
        ///     and therefore make it more informative.
        /// </param>
        /// <param name="exceptionMessage">
        ///     (Optional) Custom error message. A specific error message that can be used to describe
        ///     the exception in more detail than the default message.
        /// </param>
        /// <exception cref="ArgumentException">Will be thrown when <c>argumentValue</c> is an empty enumerable.</exception>
        /// <example>
        ///     <code>
        /// public void MyAmazingMethod(string[] myArgument)
        /// {
        ///     GuardAgainst.ArgumentBeingNullOrEmpty(myArgument, nameof(myArgument));
        /// 
        ///     ...
        /// }
        /// </code>
        /// </example>
        public static IEnumerable<T> ArgumentBeingEmpty<T>(IEnumerable<T> argumentValue,
                                                           string argumentName = null,
                                                           string exceptionMessage = null)
        {
            return ReferenceEquals(argumentValue, default(IEnumerable<T>)) || argumentValue.Any()
                ? argumentValue
                : throw new ArgumentException(exceptionMessage.ToNullIfWhitespace(), argumentName.ToNullIfWhitespace());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static string ToNullIfWhitespace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this) ? null : @this;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsWhitespace(this string @this)
        {
            return @this != null && string.IsNullOrWhiteSpace(@this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNullOrWhitespace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNullOrEmpty(this string @this)
        {
            return string.IsNullOrEmpty(@this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsEmpty(this string @this)
        {
            return @this != null && string.IsNullOrEmpty(@this);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsStringInRange(this string @this,
                                            string lowerBound,
                                            string upperBound)
        {
            return string.CompareOrdinal(@this, lowerBound) >= 0 && string.CompareOrdinal(@this, upperBound) <= 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsNull<T>(this T @this)
        {
            return ReferenceEquals(@this, null);
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
