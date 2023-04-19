namespace Template.Domain.Primitives;

public interface IRepository<T> where T : IEntity
{
    IUnitOfWork UnitOfWork { get; }
}
