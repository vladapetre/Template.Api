namespace Template.Domain.Abstractions;
public interface IRepository<TEntity> where TEntity : IEntity
{
    IUnitOfWork UnitOfWork { get; }
}
