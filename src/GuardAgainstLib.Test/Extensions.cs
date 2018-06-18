namespace GuardAgainstLib.Test
{
    public static class Extensions
    {
        public static string NullIfWhitespace(this string @this)
        {
            return string.IsNullOrWhiteSpace(@this) ? null : @this;
        }
    }
}