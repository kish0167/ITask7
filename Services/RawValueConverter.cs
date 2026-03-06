using System.Text.Json;
using System.Text.Json.Nodes;

namespace ITask7.Services;

public static class RawValueConverter
{
    public static string? ConvertToString(object? value)
    {
        return value?.ToString();
    }

    public static decimal? ConvertToDecimal(object? value)
    {
        if (value is null) return null;
        if (value is JsonElement jsonElement)
        {
            return jsonElement.ValueKind switch
            {
                JsonValueKind.String => decimal.TryParse(jsonElement.GetString(), out var result) ? result : null,
                JsonValueKind.Number => jsonElement.TryGetDecimal(out var result) ? result : null,
                _ => null
            };
        }
        if (value is string str) return decimal.TryParse(str, out var result) ? result : null;
        return value switch
        {
            decimal d => d,
            double d => (decimal)d,
            float f => (decimal)f,
            int i => i,
            long l => l,
            short s => s,
            byte b => b,
            _ => null
        };
    }

    public static bool? ConvertToBool(object? value)
    {
        if (value is null) return null;
        if (value is JsonElement jsonElement)
        {
            return jsonElement.ValueKind switch
            {
                JsonValueKind.True => true,
                JsonValueKind.False => false,
                JsonValueKind.String => ParseBoolString(jsonElement.GetString()),
                JsonValueKind.Number => jsonElement.TryGetInt64(out var num) ? num != 0 : null,
                _ => null
            };
        }
        if (value is string str)
        {
            return ParseBoolString(str);
        }
        if (value is IConvertible convertible)
        {
            try
            {
                var decimalValue = convertible.ToDecimal(null);
                return decimalValue != 0;
            }
            catch
            {
                return null;
            }
        }
        return null;
    }

    private static bool? ParseBoolString(string? str)
    {
        if (string.IsNullOrWhiteSpace(str)) return null;
        if (bool.TryParse(str, out var result)) return result;
        return str.ToLowerInvariant() switch
        {
            "1" or "yes" or "y" or "on" or "true" or "t" => true,
            "0" or "no" or "n" or "off" or "false" or "f" or "" => false,
            _ => null
        };
    }
}