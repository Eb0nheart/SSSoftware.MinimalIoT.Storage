namespace SSSoftware.MinimalIoT.Storage.DbFacade;

public interface IDbFacade<T> where T : BaseEntity
{
    Task<T> Create(T entity);

    Task<T> Update(T entity);

    Task Delete(Guid id);

    Task<ICollection<T>> GetAll();

    Task<T> Get(Guid id);
}