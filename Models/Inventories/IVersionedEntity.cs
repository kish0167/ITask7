namespace ITask7.Models.Inventories;

public interface IVersionedEntity
{
    uint RowVersion { get; set; }
}