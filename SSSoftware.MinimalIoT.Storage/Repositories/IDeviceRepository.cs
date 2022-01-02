namespace SSSoftware.MinimalIoT.Storage.Repositories;
public interface IDeviceRepository
{
    Task<Device> GetDeviceById(Guid id);
    Task CreateDevice(Device device);
    Task UpdateDevice(Device device);
    Task DeleteDevice(Guid id);
}