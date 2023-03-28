namespace System;

public static class StringExtensions
{
    public static bool EqualsIgnoreCase(this string a, string b)
    {
        return a.Equals(b, StringComparison.InvariantCultureIgnoreCase);
    }

    public static string FormatWithDictionary(this string source, Dictionary<string, string> values)
    {
        return values.Aggregate(
            source,
            (current, parameter) => current
                .Replace($"{{{parameter.Key}}}", parameter.Value));
    }
}
