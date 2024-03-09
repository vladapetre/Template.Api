namespace Template.Domain.Abstractions;
public interface IRepository<TEntity> where TEntity : class, IEntity
{
    IUnitOfWork UnitOfWork { get; }
}
