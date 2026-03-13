using System.Globalization;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Npgsql.Internal.Postgres;

namespace ITask7.Models.CustomId;

public class IdElement
{
    public IdElementType Type { get; set; }
    private string? _format;

    public string? Format
    {
        get
        {
            return _format;
        }
        set
        {
            _format = value?.Substring(0, Math.Min(value.Length, MaxLength));
        }
    }

    private const int MaxLength = 40;
    private const int MaxInt20 = 1 << 20;
    private const int MaxInt32 = 1 << 30;

    public bool IsEditableFormat => Type switch
    {
        IdElementType.Fixed => true,
        IdElementType.Int20 => true,
        IdElementType.Int32 => true,
        IdElementType.Decimal6 => false,
        IdElementType.Decimal9 => false,
        IdElementType.Guid => true,
        IdElementType.Time => true,
        IdElementType.Sequential => false,
        _ => false
    };
    
    public bool IsEditableValue => Type switch
    {
        IdElementType.Fixed => false,
        IdElementType.Int20 => true,
        IdElementType.Int32 => true,
        IdElementType.Decimal6 => true,
        IdElementType.Decimal9 => true,
        IdElementType.Guid => true,
        IdElementType.Time => true,
        IdElementType.Sequential => false,
        _ => false
    };
    
    public string? GetPreview()
    {
        string? preview;
        try
        {
            preview = GetPreviewUnsafe();
        }
        catch
        {
            return null;
        }
        
        return preview?.Length > MaxLength && IsValidValue(preview) ? null : preview;
    }

    public bool IsValidFormat()
    {
        string? result;
        try
        {
            result = GetPreviewUnsafe();
        }
        catch
        {
            return false;
        }

        return result != null
               && result.Length <= MaxLength
               && IsValidValue(result);
               //&& (Type != IdElementType.Time || IsValidValue(result));
    }

    private string? GetPreviewUnsafe()
    {
        Random random = new Random();
        return Type switch
        {
            IdElementType.Fixed => Format,
            IdElementType.Int20 => random.Next(MaxInt20).ToString(Format),
            IdElementType.Int32 => random.Next().ToString(Format),
            IdElementType.Decimal6 => random.Next(1000000).ToString("D6"),
            IdElementType.Decimal9 => random.Next(1000000000).ToString("D9"),
            IdElementType.Guid => Guid.NewGuid().ToString(Format),
            IdElementType.Time => DateTime.UtcNow.ToString(Format),
            IdElementType.Sequential => random.Next(100).ToString(Format),
            _ => null
        };
    }

    public string Generate(int sequential)
    {
        try
        {
            return Type switch
            {
                IdElementType.Fixed => Format,
                IdElementType.Int20 => RandomNumberGenerator.GetInt32(MaxInt20).ToString(Format),
                IdElementType.Int32 => RandomNumberGenerator.GetInt32(MaxInt32).ToString(Format),
                IdElementType.Decimal6 => RandomNumberGenerator.GetInt32(1000000).ToString("D6"),
                IdElementType.Decimal9 => RandomNumberGenerator.GetInt32(1000000000).ToString("D9"),
                IdElementType.Guid => Guid.NewGuid().ToString(Format),
                IdElementType.Time => DateTime.UtcNow.ToString(Format),
                IdElementType.Sequential => sequential.ToString(),
                _ => null
            } ?? "";
        }
        catch
        {
            return "";
        }
    }

    public bool IsValidValue(string value)
    {
        return Type switch
        {
            IdElementType.Fixed => value == Format,
            IdElementType.Int20 => IsValidInt20(value),
            IdElementType.Int32 => IsValidInt32(value),
            IdElementType.Decimal6 => IsValidDecimal6(value),
            IdElementType.Decimal9 => IsValidDecimal9(value),
            IdElementType.Guid => IsValidGuid(value),
            IdElementType.Time => IsValidDate(value),
            IdElementType.Sequential => true,
            _ => false
        };
    }

    private bool IsValidInt20(string value)
    {
        int? num = TryConvert(value);
        return value == num?.ToString(Format) && num < MaxInt20;
    }
    
    private bool IsValidInt32(string value)
    {
        int? num = TryConvert(value);
        return value == num?.ToString(Format) && num < MaxInt32;
        if (Int32.TryParse(value, out int num2))
        {
            return value == num2.ToString(Format) && num2 is >= 0 and < MaxInt32;
        }
        return value == 0.ToString(Format);
    }

    private int? TryConvert(string value)
    {
        int num;
        switch (Format)
        {
            case "x" or "X": // hexadecimal
                if (!int.TryParse(value, NumberStyles.HexNumber, null, out num))
                    return null;
                break;

            case "b" or "B": // binary
                try
                {
                    num = Convert.ToInt32(value, 2);
                }
                catch
                {
                    return null;
                }
                break;
            
            case "o" or "O": // oct
                try
                {
                    num = Convert.ToInt32(value, 8);
                }
                catch
                {
                    return null;
                }
                break;

            default:
                if (!int.TryParse(value, out num))
                    return null;
                break;
        }

        return num;
    }
    
    private bool IsValidDecimal6(string value)
    {
        return Int32.TryParse(value, out int num) && value == num.ToString("D6") && num < 1000000;
    }
    
    private bool IsValidDecimal9(string value)
    {
        return Int32.TryParse(value, out int num) && value == num.ToString("D9") && num < 1000000000;
    }

    private bool IsValidGuid(string value)
    {
        try
        {
            if (Guid.TryParse(value, out Guid id))
            {
                return value == id.ToString(Format);
            }

            return value == Guid.Empty.ToString(Format);
        }
        catch
        {
            return false;
        }
    }

    private bool IsValidDate(string value)
    {
        if (DateTime.TryParseExact(value, Format, CultureInfo.InvariantCulture, 
                DateTimeStyles.None, out DateTime date))
        {
            return value == date.ToString(Format);
        }

        return value == DateTime.UnixEpoch.ToString(Format);
    }

    public string GetLabel()
    {
        return Type switch
        {
            IdElementType.Fixed => "",
            IdElementType.Int20 => "Int20" + (Format.IsNullOrEmpty() ? "" : $" '{Format}'"),
            IdElementType.Int32 => "Int32" + (Format.IsNullOrEmpty() ? "" : $" '{Format}'"),
            IdElementType.Decimal6 => "6 digit decimal",
            IdElementType.Decimal9 => "9 digit decimal",
            IdElementType.Guid => "Guid" + (Format.IsNullOrEmpty() ? "" : $" '{Format}'"),
            IdElementType.Time => "Time" + (Format.IsNullOrEmpty() ? "" : $" '{Format}'"),
            IdElementType.Sequential => "Sequential number in inventory",
            _ => ""
        };
    }
}