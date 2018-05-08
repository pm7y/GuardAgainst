# GuardAgainst
A single class containing static functions that simplify checking the validity of your arguments.

### Why would I use it?

Because something like this...

```csharp
private static string GetFullName(string firstname, string surname)
{
    GuardAgainst.ArgumentBeingNullOrWhitespace(firstname, nameof(firstname), "Firstname is required.");
    GuardAgainst.ArgumentBeingNullOrWhitespace(surname, nameof(surname), "Surname is required.");

    return $"{firstname} {surname}";
}
```

Is nicer than this...

```csharp
private static string GetFullName(string firstname, string surname)
{
    if (firstname == null)
    {
        throw new ArgumentNullException(nameof(firstname), "Firstname is required.");
    }

    if (string.IsNullOrWhiteSpace(firstname))
    {
        throw new ArgumentException("Firstname is required.", nameof(firstname));
    }

    if (surname == null)
    {
        throw new ArgumentNullException(nameof(surname));
    }

    if (string.IsNullOrWhiteSpace(surname))
    {
        throw new ArgumentException("Surname is required.", nameof(surname));
    }

    return $"{firstname} {surname}";
}
```

### Available Methods

| Guard against being _null, whitespace or empty_                  | Description |
| :-                                         | :-            |
| GuardAgainst.ArgumentBeingNull             | Throws an ArgumentNullException when the value is null. |
| GuardAgainst.ArgumentBeingNullOrWhitespace | Throws an ArgumentNullException when the value is null. Throws an ArgumentException when the value is a whitespace only string. |
| GuardAgainst.ArgumentBeingWhitespace       | Throws an ArgumentException when the value is a whitespace only string. |
| GuardAgainst.ArgumentBeingNullOrEmpty      | Throws an ArgumentNullException when the value is null. Throws an ArgumentException when the value is an empty string. |
| GuardAgainst.ArgumentBeingEmpty            | Throws an ArgumentException when the value is an empty string. |
| **Guard against being _out of range_**                                    | **Description** |
| GuardAgainst.ArgumentBeingNullOrLessThanMinimum    | Throws an ArgumentNullException when the value is null. Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. |
| GuardAgainst.ArgumentBeingLessThanMinimum          | Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. |
| GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum | Throws an ArgumentNullException when the value is null. Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value. |
| GuardAgainst.ArgumentBeingGreaterThanMaximum       | Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value. |
| GuardAgainst.ArgumentBeingNullOrOutOfRange         | Throws an ArgumentNullException when the value is null. Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value. |
| GuardAgainst.ArgumentBeingOutOfRange               | Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value. |
| **Guard against being _invalid_**                                          | **Description** |
| GuardAgainst.ArgumentBeingInvalid      | Throws an ArgumentException based on whether the condition is met. |
| GuardAgainst.InvalidOperationException | Throws an InvalidOperationException based on whether the condition is met. |
