# GuardAgainst
A single class, containing static methods, to make your code more readable and to simplify argument validity checking.

---

### Installation

Just copy the [source file](../master/GuardAgainstLib/GuardAgainst.cs) into your project and change the namespace to match your own.

### Why would I use it?

Code becomes more readable and concise. Consider the following example. 
Both code snippets are logically the same. Both check that `firstname` and `surname` arguments are not null or whitespace.

Hopefully you'll agree that this...

```csharp
private static string GetFullName(string firstname, string surname)
{
    GuardAgainst.ArgumentBeingNullOrWhitespace(firstname, nameof(firstname), "Firstname is required.");
    GuardAgainst.ArgumentBeingNullOrWhitespace(surname, nameof(surname), "Surname is required.");

    return $"{firstname} {surname}";
}
```

is nicer than this...

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

---

### Why wouldn't I use it?

Using the GuardAgainst helper methods will add another step in the stack trace of the exceptions that get thrown.
It's a trade off at the end of the day. If we look at the code example above, using the GuardAgainst methods makes the code more concise and readable at the expense of that extra stack trace line.
This is the same issue though that you'd have if you chose to tidy up your own hand rolled exception handling into a private method.

**Stack strace with GuardAgainst**
```csharp
  StackTrace:
   at ExampleApp.GuardAgainst.ArgumentBeingNullOrWhitespace(String argumentValue, String argumentName, String exceptionMessage)
   at ExampleApp.Program.GetFullName(String firstname, String surname)
   at ExampleApp.Program.Main(String[] args)
```

**Stack strace without GuardAgainst**
```csharp
  StackTrace:
   at ExampleApp.Program.GetFullName(String firstname, String surname)
   at ExampleApp.Program.Main(String[] args)
```

---

### Available Methods

| Guard against being _null, whitespace or empty_                  | Description |
| :-                                         | :-            |
| GuardAgainst.ArgumentBeingNull             | Throws an ArgumentNullException when the value is null. |
| GuardAgainst.ArgumentBeingNullOrWhitespace | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentException when the value is a whitespace only string. |
| GuardAgainst.ArgumentBeingWhitespace       | Throws an ArgumentException when the value is a whitespace only string. |
| GuardAgainst.ArgumentBeingNullOrEmpty      | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentException when the value is an empty string. |
| GuardAgainst.ArgumentBeingEmpty            | Throws an ArgumentException when the value is an empty string. |
| **Guard against being _out of range_**                                    | **Description** |
| GuardAgainst.ArgumentBeingNullOrLessThanMinimum    | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. |
| GuardAgainst.ArgumentBeingLessThanMinimum          | Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. |
| GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value. |
| GuardAgainst.ArgumentBeingGreaterThanMaximum       | Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value. |
| GuardAgainst.ArgumentBeingNullOrOutOfRange         | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. <br/>Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value. |
| GuardAgainst.ArgumentBeingOutOfRange               | Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. <br/>Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value. |
| **Guard against being _invalid_**                                          | **Description** |
| GuardAgainst.ArgumentBeingInvalid      | Throws an ArgumentException based on whether the condition is met. |
| GuardAgainst.InvalidOperationException | Throws an InvalidOperationException based on whether the condition is met. |

### Alternatives

You could use something like `System.Diagnostics.Contracts`, `Fody Weavers`, `PostSharp` and others. 
These solutions rely on annotating code with attributes (e.g. [NotNull]), then at compile time the IL is manipulated to add the necessary code to check for the conditions you want to prevent.
It's possible to set global policies like _no arguments should be null_. This is great since you don't have to add this check to every method and you can add exceptions as you go.

These are very powerful solutions and can be cleaner because you completely remove any boiler plate code from your files. 
This can also be a downside though and can sometimes mean the argument checking logic becomes somewhat hidden and if developers aren't fully aware of it they may end up adding their own checking.

They often require additional tools to be installed on the developer/ build machine. They may require some specific project configuration. If they don't offer the feature you need OOTB then you may have to write your own which could be complicated. It's another thing to setup and maintain. Which is totally fine and may well be worth the extra effort to do this. 
Sometimes though you just want something you can drop in without any extra setup and get coding.


### TODO

A brain dump of some stuff I might add at somepoint. Not in any particular order.

- Need to drastically improve test coverage.
- Add a NuGet package option (dll or cs file?).
- Think about logging support. Maybe via LibLog.
- More examples & docs.
- Add support for adding `Data` name/value pairs.
