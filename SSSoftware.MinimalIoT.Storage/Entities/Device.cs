namespace SSSoftware.MinimalIoT.Storage.Entities;

public class Device : BaseEntity
{
    public Guid OwnerId { get; set; }

    public string Name { get; set; }
}