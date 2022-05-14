using System;
using System.Net;
using Shouldly;
using Xunit;
using Xunit.Abstractions;

namespace GuardAgainstLib.Test;

public class TestUsage
{
    [Fact]
    public void WhenArgumentIsEmptyGuid_ShouldThrowArgumentException()
    {
        GuardAgainst.ArgumentBeingEmpty(Guid.NewGuid());
        GuardAgainst.ArgumentBeingEmpty(" ");
        GuardAgainst.ArgumentBeingEmpty(new[] {""});

        GuardAgainst.ArgumentBeingWhitespace(" d");

        GuardAgainst.ArgumentBeingGreaterThanMaximum("A", "B");
        GuardAgainst.ArgumentBeingGreaterThanMaximum(null, "B");
        GuardAgainst.ArgumentBeingGreaterThanMaximum<string>(null, null);
        GuardAgainst.ArgumentBeingGreaterThanMaximum(1, 2);

        GuardAgainst.ArgumentBeingNullOrGreaterThanMaximum("A", "B");

        GuardAgainst.ArgumentBeingInvalidEnum(HttpStatusCode.OK, HttpStatusCode.InternalServerError);

        GuardAgainst.ArgumentBeingLessThanMinimum("B", "A");
        GuardAgainst.ArgumentBeingLessThanMinimum("B", null);
        GuardAgainst.ArgumentBeingLessThanMinimum(null, "A");
        GuardAgainst.ArgumentBeingLessThanMinimum<string>(null, null);
        GuardAgainst.ArgumentBeingLessThanMinimum(2, 1);

        GuardAgainst.ArgumentBeingNullOrLessThanMinimum("B", "A");
        GuardAgainst.ArgumentBeingNullOrLessThanMinimum("B", null);

        GuardAgainst.ArgumentBeingNull("");
        GuardAgainst.ArgumentBeingNull((int?)1);

        GuardAgainst.ArgumentBeingNullOrEmpty(new[] {""});
        GuardAgainst.ArgumentBeingNullOrEmpty("a");

        GuardAgainst.ArgumentBeingNullOrWhitespace("  d");

        GuardAgainst.ArgumentBeingNullOrOutOfRange("B", "A", "C");
        GuardAgainst.ArgumentBeingNullOrOutOfRange("B", null, "C");

        GuardAgainst.ArgumentBeingOutOfRange("B", "A", "C");
        GuardAgainst.ArgumentBeingOutOfRange(null, "A", "C");
        GuardAgainst.ArgumentBeingOutOfRange("B", null, "C");
        GuardAgainst.ArgumentBeingOutOfRange(null, null, "C");
        GuardAgainst.ArgumentBeingOutOfRange(2, 1, 3);

        GuardAgainst.OperationBeingInvalid(false);

    }

}
