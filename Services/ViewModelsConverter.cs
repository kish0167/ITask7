using System.Text.Json;
using System.Text.RegularExpressions;
using ITask7.Models.Inventories;
using ITask7.Users;
using ITask7.ViewModels;
using ITask7.ViewModels.Inventories;

namespace ITask7.Services;

public class ViewModelsConverter()
{
    public InventoryField GetNewField(FieldDefinitionViewModel fieldViewModel, Inventory inventory)
    {
        InventoryField field = new()
        {
            Id = Guid.NewGuid(),
            InventoryId = inventory.Id,
            Title = fieldViewModel.Title,
            Name = Regex.Replace(fieldViewModel.Title, @"(\B[A-Z])", "_$1").ToLower(),
            FieldType = fieldViewModel.Type,
            Description = fieldViewModel.Description,
            CreatedAt = DateTime.UtcNow,
            DisplayInTable = fieldViewModel.DisplayInTable,
            IsRequired = fieldViewModel.IsRequired,
            SortOrder = inventory.Fields.Any() ?
                inventory.Fields.Select(f=>f.SortOrder).ToList().Max() + 1
                : 1
        };
        return field;
    }

    public void EditFieldProperties(InventoryField field, FieldDefinitionViewModel fieldViewModel)
    {
        field.Title = fieldViewModel.Title;
        field.Name = TitleToName(fieldViewModel.Title);
        field.Description = fieldViewModel.Description;
        field.DisplayInTable = fieldViewModel.DisplayInTable;
        field.IsRequired = fieldViewModel.IsRequired;
    }
    
    private string TitleToName(string title)
    {
        return Regex.Replace(title, @"(\B[A-Z])", "_$1").ToLower();
    }
    
}