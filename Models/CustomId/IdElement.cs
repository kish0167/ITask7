using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ITask7.Models.CustomId;

public class IdElement
{
    public IdElementType Type { get; set; }
    public string? Value { get; set; }
    private const int MaxLength = 40;

    public string? GetPreview()
    {
        try
        {
            return GetPreviewUnsafe();
        }
        catch
        {
            return null;
        }
    }

    public bool IsValid()
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

        return result != null && result.Length <= MaxLength;
    }

    private string? GetPreviewUnsafe()
    {
        Random random = new Random();
        return Type switch
        {
            IdElementType.Fixed => Value,
            IdElementType.Int20 => random.Next(1 << 20).ToString(Value),
            IdElementType.Int32 => random.Next().ToString(Value),
            IdElementType.Decimal6 => random.Next(1000000).ToString("D6"),
            IdElementType.Decimal9 => random.Next(1000000000).ToString("D9"),
            IdElementType.Guid => Guid.NewGuid().ToString(Value),
            IdElementType.Time => DateTime.UtcNow.ToString(Value),
            IdElementType.Sequence => random.Next(100).ToString(Value),
            _ => null
        };
    }

    public string Generate(int sequential)
    {
        try
        {
            return Type switch
            {
                IdElementType.Fixed => Value,
                IdElementType.Int20 => RandomNumberGenerator.GetInt32(1 << 20).ToString(Value),
                IdElementType.Int32 => RandomNumberGenerator.GetInt32(1 << 30).ToString(Value),
                IdElementType.Decimal6 => RandomNumberGenerator.GetInt32(1000000).ToString("D6"),
                IdElementType.Decimal9 => RandomNumberGenerator.GetInt32(1000000000).ToString("D9"),
                IdElementType.Guid => Guid.NewGuid().ToString(Value),
                IdElementType.Time => DateTime.UtcNow.ToString(Value),
                IdElementType.Sequence => sequential.ToString(Value),
                _ => null
            } ?? "";
        }
        catch
        {
            return "";
        }
    }
}