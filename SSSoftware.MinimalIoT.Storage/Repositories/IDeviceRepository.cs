namespace SSSoftware.MinimalIoT.Storage.Repositories;
public interface IDeviceRepository
{
    Task<Device> GetDevicesByUserId(Guid userId);
    Task<Device> GetDeviceById(Guid id);
    Task CreateDevice(Device device);
    Task UpdateDevice(Device device);
    Task DeleteDevice(Guid id);
}