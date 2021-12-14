namespace SSSoftware.MinimalIoT.Storage.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private static ICollection<Device> _devices = new Collection<Device>();

    public async Task CreateDevice(Device device)
    {
        _devices.Add(device);
    }

    public async Task DeleteDevice(Guid id)
    {
        var deviceToRemove = _devices.FirstOrDefault(device => device.Id == id);
        _ = deviceToRemove ?? throw new ArgumentException($"Device with id: {id} could not be found!");

        _devices.Remove(deviceToRemove);
    }

    public async Task<Device> GetDeviceById(Guid id)
        => _devices.FirstOrDefault(device => device.Id == id);


    public async Task<Device> GetDevicesByUserId(Guid userId)
        => _devices.FirstOrDefault(device => device.OwnerId == userId);

    public async Task UpdateDevice(Device device)
    {
        _devices.Remove(await GetDeviceById(device.Id));
        _devices.Add(device);
    }
}
