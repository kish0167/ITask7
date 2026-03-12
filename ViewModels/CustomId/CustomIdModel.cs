using ITask7.Models.CustomId;
using ITask7.Models.Inventories;
using Microsoft.IdentityModel.Tokens;

namespace ITask7.ViewModels.CustomId;

public class CustomIdModel
{
    public List<string> Values { get; set; } = new();
    public CustomIdSchema Schema { get; set; }
    private string _original;
    private List<string> Errors { get; } = new();
    
    public CustomIdModel(){}
    
    public CustomIdModel(Inventory inventory)
    {
        Schema = new CustomIdSchema(inventory.CustomIdSchemaJson);
        Values = Schema.GenerateNew(inventory.Sequential);
        _original = "";
    }
    
    public CustomIdModel(Item item, string schemaJson)
    {
        Schema = new CustomIdSchema(schemaJson);
        _original = item.CustomId;
        string[] values = item.CustomId.Split(Schema.Separator);
        for (int i = 0; Values.Count < Schema.Elements.Count; i++)
        {
            Values.Add(i < values.Length ? values[i] : "");
        }

        InjectSequential(item.SequentialNumber);
    }

    public void InjectSequential(int itemSequentialNumber)
    {
        for (int i = 0; i < Schema.Elements.Count; i++)
        {
            if (Schema.Elements[i].Type == IdElementType.Sequential)
            {
                Values[i] = itemSequentialNumber.ToString();
            }
        }
    }

    public string GetPreview()
    {
        return String.Join("",Values);
    }
    
    public string ToPrintString()
    {
        return _original.Replace(Schema.Separator.ToString(), "");
    }
    
    public string ToStorageString()
    {
        return String.Join(Schema.Separator, Values);
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
    
    private bool IsValid()
    {
        bool isValid = true;
        List<IdElement> elements = Schema.Elements;
        Errors.Clear();
        for (int i = 0; i < elements.Count; i++)
        {
            if (elements[i].IsValidValue(Values[i])) continue;
            Errors.Add($"{elements[i].Type.ToString()} formatting error ({i+1})");
            isValid = false;
        }
        return isValid;
    }
}