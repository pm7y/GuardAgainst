<img src="/src/GuardAgainstLib/logo/GuardAgainstSquare.png" width="64">

# GuardAgainst [![Build and Tests](https://github.com/pmcilreavy/GuardAgainst/workflows/Build%20and%20Test/badge.svg)](https://github.com/pmcilreavy/GuardAgainst)

Useful guard clauses that simplify argument validity checking and make your code more readable.

<br/>

## Installation

### Via Source

Just copy the [source file](/src/GuardAgainstLib/GuardAgainst.cs) into your project and change the namespace to match your own.

### Via NuGet

```
Install-Package GuardAgainst
```

<br/>

## Why would I use it?

Code becomes more readable and concise. Consider the following example: a simple `GetFullname` method that concatenates a `firstname` and `surname` string together.

```csharp
private static string GetFullname(string firstname, string surname)
{
    if (firstname is null)
    {
        throw new ArgumentNullException(nameof(firstname), "Firstname is required.");
    }

    if (string.IsNullOrWhiteSpace(firstname))
    {
        throw new ArgumentException("Firstname is required.", nameof(firstname));
    }

    if (surname is null)
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

It checks that `firstname` and `surname` arguments are not null or whitespace and throws an `ArgumentNullException` or `ArgumentException` respectively.
The `nameof` the offending argument is passed to the exception constructor so that when the exception is thrown we'll know the name of argument that was at fault.

This kind of boiler plate code is tedious to write, can be error prone in itself, and can add unneccessary cognitive load when scanning the source.
_GuardAgainst_ aims to abstract this boiler plate code into a series of static helper methods that you can use to achieve the same result.

Hopefully you'll agree that this is much simpler and easier to read...

```csharp
private static string GetFullname(string firstname, string surname)
{
    GuardAgainst.ArgumentBeingNullOrWhitespace(firstname, nameof(firstname), "Firstname is required.");
    GuardAgainst.ArgumentBeingNullOrWhitespace(surname, nameof(surname), "Surname is required.");

    return $"{firstname} {surname}";
}
```

Both implementations of `GetFullname` are achieving the exact same thing.

`GuardAgainst.ArgumentBeingNullOrWhitespace` accepts 2 main arguments: -

- `argumentValue` is required. This is the value that you want to validate.
- `argumentName` is optional. Supplying this makes the exception more useful particularly if the method has several parameters.
- `exceptionMessage` is optional. Allows you to give an additional specific error message to pass to the exception constructor.

<br/>

There are several other helper methods available that act in a similar fashion. See table below for the full list.

## Available Methods

| Guard against being _null, whitespace or empty_    | Description                                                                                                                                                                                                                                                    |
| :------------------------------------------------- | :------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| GuardAgainst.ArgumentBeingNull                     | Throws an ArgumentNullException when the value is null.                                                                                                                                                                                                        |
| GuardAgainst.ArgumentBeingNullOrWhitespace         | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentException when the value is a whitespace only string.                                                                                                                           |
| GuardAgainst.ArgumentBeingWhitespace               | Throws an ArgumentException when the value is a whitespace only string.                                                                                                                                                                                        |
| GuardAgainst.ArgumentBeingNullOrEmpty              | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentException when the value is an empty string.                                                                                                                                    |
| GuardAgainst.ArgumentBeingEmpty                    | Throws an ArgumentException when the value is an empty string or Enumerable.                                                                                                                                                                                   |
| **Guard against being _out of range_**             | **Description**                                                                                                                                                                                                                                                |
| GuardAgainst.ArgumentBeingNullOrLessThanMinimum    | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value.                                                                                                      |
| GuardAgainst.ArgumentBeingLessThanMinimum          | Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value.                                                                                                                                                                   |
| GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value.                                                                                                   |
| GuardAgainst.ArgumentBeingGreaterThanMaximum       | Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value.                                                                                                                                                                |
| GuardAgainst.ArgumentBeingNullOrOutOfRange         | Throws an ArgumentNullException when the value is null. <br/>Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. <br/>Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value. |
| GuardAgainst.ArgumentBeingOutOfRange               | Throws an ArgumentOutOfRangeException when the value is less than the minimum allowed value. <br/>Throws an ArgumentOutOfRangeException when the value is greater than the maximum allowed value.                                                              |
| **Other**                                          | **Description**                                                                                                                                                                                                                                                |
| GuardAgainst.ArgumentBeingInvalid                  | Throws an ArgumentException based on whether the condition is met.                                                                                                                                                                                             |
| GuardAgainst.OperationBeingInvalid                 | Throws an InvalidOperationException if the condition is not satisfied.                                                                                                                                                                                         |
| GuardAgainst.ArgumentNotBeingUtcDateTime           | Throws an ArgumentException if the DateTime argument is not Utc.                                                                                                                                                                                               |

<br/>

## Why wouldn't I use it?

There are actually a few reasons you might not want to use a guard clause library. Travis Illig has a nice blog post detailing a few of them.

[https://www.paraesthesia.com/archive/2011/09/30/six-reasons-not-to-use-guard-classes.aspx/](https://www.paraesthesia.com/archive/2011/09/30/six-reasons-not-to-use-guard-classes.aspx/)

Here's the tl;dr; of his article with some of my counter arguments.

- _"Guard classes defeat static analysis like FxCop."_
  - **You shouldn't have to change your code to work around short comings in your static analysis tools. Your tools should work for you, not the other way around. Is FxCop still even a thing?**
- _"Guard classes become giant validation dumping grounds."_
  - **I like to think _GuardAgainst_ supports a useful and flexible set of scenarios.**
- _"Guard classes mess up the call stack."_
  - **True, there's no getting around it. _GuardAgainst_ will add one extra line. But when you look at the call stack of the error message this should be completely obvious and you should see exactly which parameter caused the exception and why.**
- _"Guard classes become a single point of failure."_
  - **That could be said of many libraries out there though (e.g. the npm padleft debacle). Pick a good library (like GuardAgainst 😉) and report bugs or raise a PR to fix issues if you encounter them.**
- _"Guard classes tend to get used in the wrong places."_
  - **Any language or tool can be used and abused in the wrong way. Bad developers will always find a way to do the wrong thing. That's not a problem unique to guard clause libraries.**
- _"Guard classes fool your unit test coverage."_
  - **True, you do still have to take care to cover all the same test cases appropriate for your methods as you would if you weren't using a guard clause library.**

It's a trade off at the end of the day and you have to weigh up the convenience and consistency with the possible downsides.

<br/>

## Alternatives

You could use something like `System.Diagnostics.Contracts`, `Fody Weavers`, `PostSharp` and others.
These solutions rely on annotating code with attributes (e.g. [NotNull]), then at compile time the IL is manipulated to add the necessary code to check for the conditions you want to prevent.
It's possible to set global policies like _no arguments should be null_. This is great since you don't have to add this check to every method and you can add exceptions as you go.

These are very powerful solutions and can be cleaner because you completely remove any boiler plate code from your files.
This can also be a downside though and can sometimes mean the argument checking logic becomes somewhat hidden and if developers aren't fully aware of it they may end up adding their own checking.

They often require additional tools to be installed on the developer/ build machine. They may require some specific project configuration. If they don't offer the feature you need OOTB then you may have to write your own which could be complicated. It's another thing to setup and maintain. Which is totally fine and may well be worth the extra effort to do this.
Sometimes though you just want something you can drop in without any extra setup and get coding.

<br/>

## TODO

A few things I might add at some point. Not in any particular order.

- Think about logging support. Maybe via LibLog.

<br/>

Queen's Guard Icon by Angelo Troiano from the Noun Project
