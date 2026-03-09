using ITask7.Models.CustomId;
using ITask7.Models.Inventories;

namespace ITask7.ViewModels.CustomId;

public class CustomIdViewModel
{
    private CustomIdSchema Schema { get; set; }
    public Dictionary<IdElement, string> Elements { get; set; } = new();
    private const string Separator = "/";
    
    public CustomIdViewModel(){}
    
    public CustomIdViewModel(Inventory inventory)
    {
        Schema = new CustomIdSchema(inventory.CustomIdSchemaJson);
        Elements = Schema.GenerateNew(inventory.Sequential);
    }
    
    public CustomIdViewModel(string id, Inventory inventory)
    {
        Schema = new CustomIdSchema(inventory.CustomIdSchemaJson);
        string[] values = id.Split(Separator);
        for (int i = 0; i < values.Length && i < Schema.Elements.Count; i++)
        {
            Elements.Add(Schema.Elements[i], values[i]);
        }
    }

    public override string ToString()
    {
        return String.Join(Separator, Elements.Select(e => e.Value));
    }
}