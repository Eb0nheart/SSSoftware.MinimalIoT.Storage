namespace SSSoftware.MinimalIoT.Storage.DbFacade;

public interface IDbFacade<T> where T : BaseEntity
{
    Task<bool> Create(T entity);

    Task<bool> Update(T entity);

    Task<bool> Delete(Guid id);

    Task<IEnumerable<T>> GetAll();

    Task<T> Get(Guid id);
}