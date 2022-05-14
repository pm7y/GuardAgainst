using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace GuardAgainstLib;

public static class GuardAgainst
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NotNull]
    public static T ArgumentBeingNull<T>(T? argumentValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : class
    {
        return argumentValue ?? throw new ArgumentNullException(argumentName, msg);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ArgumentBeingNull<T>(T? argumentValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : struct
    {
        return argumentValue ?? throw new ArgumentNullException(argumentName, msg);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ArgumentBeingNullOrWhitespace(string? argumentValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
    {
        if (!string.IsNullOrWhiteSpace(argumentValue))
        {
            return argumentValue;
        }

        _ = argumentValue ?? throw new ArgumentNullException(argumentName, msg);

        throw new ArgumentException(msg, argumentName);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ArgumentBeingWhitespace(string? argumentValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
    {
        return argumentValue != null && string.IsNullOrWhiteSpace(argumentValue)
            ? throw new ArgumentException(msg, argumentName)
            : argumentValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ArgumentBeingNullOrEmpty(string? argumentValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
    {
        if (!string.IsNullOrEmpty(argumentValue))
        {
            return argumentValue;
        }

        _ = argumentValue ?? throw new ArgumentNullException(argumentName, msg);

        throw new ArgumentException(msg, argumentName);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ArgumentBeingEmpty(string? argumentValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
    {
        return argumentValue != null && string.IsNullOrEmpty(argumentValue)
            ? throw new ArgumentException(msg, argumentName)
            : argumentValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [return: NotNull]
    public static T ArgumentBeingNullOrLessThanMinimum<T>(T? argumentValue,
        T? minimumAllowedValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : class, IComparable<T>
    {
        _ = argumentValue ?? throw new ArgumentNullException(argumentName, msg);

        return argumentValue.CompareTo(minimumAllowedValue) < 0
            ? throw new ArgumentOutOfRangeException(argumentName, argumentValue, msg)
            : argumentValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? ArgumentBeingLessThanMinimum<T>(T? argumentValue,
        T? minimumAllowedValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : class, IComparable<T>
    {
        return argumentValue is null
            ? default
            : argumentValue.CompareTo(minimumAllowedValue) < 0
                ? throw new ArgumentOutOfRangeException(argumentName, argumentValue, msg)
                : argumentValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? ArgumentBeingLessThanMinimum<T>(T? argumentValue,
        T minimumAllowedValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : struct, IComparable<T>
    {
        return !argumentValue.HasValue
            ? default
            : argumentValue.Value.CompareTo(minimumAllowedValue) < 0
                ? throw new ArgumentOutOfRangeException(argumentName, argumentValue, msg)
                : argumentValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ArgumentBeingNullOrGreaterThanMaximum<T>(T? argumentValue,
        T? maximumAllowedValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : class, IComparable<T>
    {
        _ = argumentValue ?? throw new ArgumentNullException(argumentName, msg);

        return argumentValue.CompareTo(maximumAllowedValue) > 0
            ? throw new ArgumentOutOfRangeException(argumentName,
                argumentValue,
                msg)
            : argumentValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? ArgumentBeingGreaterThanMaximum<T>(T? argumentValue,
        T? maximumAllowedValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : class, IComparable<T>
    {
        return argumentValue is null
            ? default
            : argumentValue.CompareTo(maximumAllowedValue) > 0
                ? throw new ArgumentOutOfRangeException(argumentName,
                    argumentValue,
                    msg)
                : argumentValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? ArgumentBeingGreaterThanMaximum<T>(T? argumentValue,
        T maximumAllowedValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : struct, IComparable<T>
    {
        return !argumentValue.HasValue
            ? default
            : argumentValue.Value.CompareTo(maximumAllowedValue) > 0
                ? throw new ArgumentOutOfRangeException(argumentName,
                    argumentValue,
                    msg)
                : argumentValue;
    }


    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T ArgumentBeingNullOrOutOfRange<T>(T? argumentValue,
        T? minimumAllowedValue,
        T? maximumAllowedValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : class, IComparable<T>
    {
        _ = argumentValue ??
            throw new ArgumentNullException(argumentName, msg);

        return argumentValue.CompareTo(minimumAllowedValue) >= 0 && argumentValue.CompareTo(maximumAllowedValue) <= 0
            ? argumentValue
            : throw new ArgumentOutOfRangeException(argumentName,
                argumentValue,
                msg);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T? ArgumentBeingOutOfRange<T>(T? argumentValue,
        T? minimumAllowedValue,
        T? maximumAllowedValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
        where T : IComparable<T>
    {
        return argumentValue is null
            ? default
            : argumentValue.CompareTo(minimumAllowedValue) >= 0 && argumentValue.CompareTo(maximumAllowedValue) <= 0
                ? argumentValue
                : throw new ArgumentOutOfRangeException(argumentName,
                    argumentValue,
                    msg);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ArgumentBeingInvalidEnum<T>(T argumentValue, T invalidEnum,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null) where T : Enum
    {
        return argumentValue.Equals(invalidEnum)
            ? throw new ArgumentException(msg,
                argumentName)
            : false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool OperationBeingInvalid(bool operationIsInvalid,
        string? msg = null)
    {
        return operationIsInvalid
            ? throw new InvalidOperationException(msg)
            : false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T> ArgumentBeingNullOrEmpty<T>(IEnumerable<T>? argumentValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
    {
        _ = argumentValue ?? throw new ArgumentNullException(argumentName, msg);

        return argumentValue.Any()
            ? argumentValue
            : throw new ArgumentException(msg, argumentName);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Guid ArgumentBeingEmpty(Guid argumentValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
    {
        return argumentValue == Guid.Empty
            ? throw new ArgumentException(msg, argumentName)
            : argumentValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<T>? ArgumentBeingEmpty<T>(IEnumerable<T>? argumentValue,
        [CallerArgumentExpression("argumentValue")]
        string? argumentName = null,
        string? msg = null)
    {
        return argumentValue is null || argumentValue.Any()
            ? argumentValue
            : throw new ArgumentException(msg, argumentName);
    }
}
