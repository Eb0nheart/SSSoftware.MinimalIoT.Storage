using Dapper;
using SSSoftware.MinimalIoT.Storage.Options;
using System.Data;
using System.Data.SqlClient;

namespace SSSoftware.MinimalIoT.Storage.DbFacade;

public class DeviceDbFacade : IDbFacade<Device>, IAsyncDisposable
{
    private IDbConnection dbConnection;

    public DeviceDbFacade(DeviceDbFacadeOptions options)
    {
        dbConnection = new SqlConnection(options.ConnectionString);
    }

    public async Task<bool> Create(Device entity)
    {
        var columnsList = typeof(Device).GetProperties().Select(property => property.Name);
        var columnsListWithAt = columnsList.Select(name => $"@{name}");
        var columns = string.Join(",", columnsList);
        var columnsWithAt = string.Join(",", columnsListWithAt);

        var rowsAffected = await dbConnection.ExecuteAsync($"insert into dbo.Devices ({columns}) values {columnsWithAt}", entity);

        return rowsAffected == 1;
    }

    public async Task<bool> Delete(Guid id)
    {
        var rowsAffected = await dbConnection.ExecuteAsync($"delete from dbo.Devices where {nameof(Device.Id)}='{id}'");
        return rowsAffected == 1;
    }

    public async Task<Device> Get(Guid id)
        => await dbConnection.QuerySingleAsync<Device>($"Select * from dbo.devices where {nameof(Device.Id)}='{id}'");

    public async Task<IEnumerable<Device>> GetAll()
        => await dbConnection.QueryAsync<Device>("Select * from dbo.devices");

    public Task<bool> Update(Device entity)
    {
        throw new NotImplementedException();
    }

    public async ValueTask DisposeAsync()
    {
        dbConnection.Close();
        dbConnection.Dispose();
        dbConnection = null;
    }
}
