using System;
using GuardAgainstLib;

namespace ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var fullname = GetFullName("Joe", "Bloggs");

            Console.WriteLine(fullname);
        }

        private static string GetFullName(string firstname, string surname)
        {
            GuardAgainst.ArgumentBeingNullOrWhitespace(firstname, nameof(firstname), "Firstname is required.");
            GuardAgainst.ArgumentBeingNullOrWhitespace(surname, nameof(surname), "Surname is required.");
            GuardAgainst.ArgumentBeingInvalid(firstname.Length <= 1, nameof(firstname), "Firstname must be longer than 1 character.");
            GuardAgainst.ArgumentBeingInvalid(surname.Length <= 1, nameof(surname), "Surname must be longer than 1 character.");

            return $"{firstname} {surname}";
        }

        private static string GetFullNameWithoutGuardAgainst(string firstname, string surname)
        {
            if (firstname == null)
            {
                throw new ArgumentNullException(nameof(firstname), "Firstname is required.");
            }

            if (string.IsNullOrWhiteSpace(firstname))
            {
                throw new ArgumentException("Firstname is required.", nameof(firstname));
            }

            if (firstname.Length <= 1)
            {
                throw new ArgumentException("Firstname must be longer than 1 character.", nameof(firstname));
            }

            if (surname == null)
            {
                throw new ArgumentNullException(nameof(surname));
            }

            if (string.IsNullOrWhiteSpace(surname))
            {
                throw new ArgumentException("Surname is required.", nameof(surname));
            }

            if (surname.Length <= 1)
            {
                throw new ArgumentException("Surname must be longer than 1 character.", nameof(surname));
            }

            return $"{firstname} {surname}";
        }
    }
}
