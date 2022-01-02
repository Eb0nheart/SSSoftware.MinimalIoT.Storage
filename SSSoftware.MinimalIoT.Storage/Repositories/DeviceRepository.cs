using SSSoftware.MinimalIoT.Storage.DbFacade;

namespace SSSoftware.MinimalIoT.Storage.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly IDbFacade<Device> dbFacade;

    public DeviceRepository(IDbFacade<Device> dbFacade)
    {
        this.dbFacade = dbFacade;
    }

    public async Task CreateDevice(Device device)
        => await dbFacade.Create(device);

    public async Task DeleteDevice(Guid id)
        => await dbFacade.Delete(id);

    public async Task<Device> GetDeviceById(Guid id)
        => await dbFacade.Get(id);

    public async Task UpdateDevice(Device device)
        => await dbFacade.Update(device);
}
