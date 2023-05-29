using Template.Domain.Primitives;

namespace Template.Infrastructure.Mappers;

public interface IMapper<TFrom, TTo> where TFrom : IEntity
{
    public Task<TTo?> Map(TFrom from);
    public Task<TFrom?> Map(TTo to);
}
