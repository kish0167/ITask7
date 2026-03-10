using System.Numerics;
using ITask7.ViewModels.CustomId;
using Newtonsoft.Json;

namespace ITask7.Models.CustomId;

public class CustomIdSchema
{
    public List<IdElement> Elements { get; set; } = new();
    public char Separator => '\x1F';
    private List<string> Errors { get;  } = new();
    private const int MaxElements = 10;
    private const int MinElements = 1;
    
    public CustomIdSchema(){}
    
    public CustomIdSchema(string json)
    {
        Elements = new List<IdElement>();
        if (string.IsNullOrWhiteSpace(json)) return;
        try
        {
            List<IdElement>? elements = JsonConvert.DeserializeObject<List<IdElement>>(json);
            if (elements != null) Elements = elements;
        }
        catch (JsonException)
        {
            return;
        }
    }

    public static CustomIdSchema Default()
    {
        return new CustomIdSchema()
        {
            Elements =
            [
                new IdElement()
                {
                    Type = IdElementType.Fixed,
                    Format = "custom-"
                },
                new IdElement()
                {
                    Type = IdElementType.Guid,
                    Format = ""
                }
            ]
        };
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(Elements, Formatting.None);
    }

    public ValidationResult Validate()
    {
        return new ValidationResult()
        {
            Preview = GetPreview(),
            IsValid = IsValid(),
            Errors = Errors
        };
    }

    public List<string> GenerateNew(int sequential)
    {
        List<string> id = new();
        foreach (IdElement element in Elements)
        {
            id.Add(element.Generate(sequential).Replace(Separator.ToString(), ""));
        }
        return id;
    }

    private string GetPreview()
    {
        string preview = "";
        for (int i = 0; i < Elements.Count; i++)
        {
            string? elementPreview = Elements[i].GetPreview();
            preview += elementPreview ?? $" <{Elements[i].Type.ToString()} formatting error ({i+1})> ";
        }
        return preview;
    }

    private bool IsValid()
    {
        Errors.Clear();
        bool elements = ElementFormatsOk();
        bool count = ElementCountOk();
        bool uniqueness = EnoughUniqueness();
        return elements && count && uniqueness;
    }

    private bool ElementFormatsOk()
    {
        bool isOk = true;
        for (int i = 0; i < Elements.Count; i++)
        {
            if (Elements[i].IsValidFormat()) continue;
            Errors.Add($"{Elements[i].Type.ToString()}({i+1}) invalid format");
            isOk = false;
        }
        return isOk;
    }

    private bool ElementCountOk()
    {
        if (Elements.Count < MinElements)
        {
            Errors.Add("Too little elements");
            return false;
        }

        if (Elements.Count > MaxElements)
        {
            Errors.Add("Too much elements");
            return false;
        }

        return true;
    }

    private bool EnoughUniqueness()
    {
        if (Elements.Any(e => e.Type == IdElementType.Int20)) return true;
        if (Elements.Any(e => e.Type == IdElementType.Int32)) return true;
        if (Elements.Any(e => e.Type == IdElementType.Decimal6)) return true;
        if (Elements.Any(e => e.Type == IdElementType.Decimal9)) return true;
        if (Elements.Any(e => e.Type == IdElementType.Sequential)) return true;
        if (Elements.Any(e => e.Type == IdElementType.Guid)) return true;
        Errors.Add("Not enough uniqueness");
        return false;
    }
}