using System.Numerics;
using ITask7.Services.CustomId;
using Newtonsoft.Json;

namespace ITask7.Models.CustomId;

public class CustomIdSchema
{
    public List<IdElement> Elements { get; set; } = new();
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

    public string ToJson()
    {
        return JsonConvert.SerializeObject(Elements, Formatting.None);
    }

    public SchemaValidationResult Validate()
    {
        return new SchemaValidationResult()
        {
            Preview = GetPreview(),
            IsValid = IsValid(),
            Errors = Errors
        };
    }

    public Dictionary<IdElement, string> GenerateNew(int sequential)
    {
        Dictionary<IdElement, string> id = new();
        foreach (IdElement element in Elements)
        {
            id.Add(element, element.Generate(sequential));
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
        bool elements = ElementsOk();
        bool count = ElementCountOk();
        bool uniqueness = EnoughUniqueness();
        return elements && count && uniqueness;
    }

    private bool ElementsOk()
    {
        if (Elements.All(e => e.IsValid())) return true;
        Errors.Add("At least one element contains formatting error");
        return false;
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
        if (Elements.Any(e => e.Type == IdElementType.Decimal9)) return true;
        if (Elements.Any(e => e.Type == IdElementType.Decimal9)) return true;
        if (Elements.Any(e => e.Type == IdElementType.Sequence)) return true;
        Errors.Add("Not enough uniqueness");
        return false;
    }
}