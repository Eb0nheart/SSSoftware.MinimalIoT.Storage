namespace SSSoftware.MinimalIoT.Storage.Entities;

public class Device
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string Name { get; set; }
}