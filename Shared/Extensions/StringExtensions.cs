using System;

namespace TodoApi.Shared.Extensions;

public static partial class StringExtensions
{
    public static string Pluralize(this string input)
    {

        if (input.EndsWith('y'))
            return string.Concat(input.AsSpan(0, input.Length - 1), "ies");

        return input + "s";
    }
    public static string ToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

       
        var result = MyRegex().Replace(input, "$1_$2").ToLower();

        return result;
    }

    [System.Text.RegularExpressions.GeneratedRegex("([a-z])([A-Z])")]
    private static partial System.Text.RegularExpressions.Regex MyRegex();
}
