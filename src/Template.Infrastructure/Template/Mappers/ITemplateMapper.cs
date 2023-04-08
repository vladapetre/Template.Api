using Template.Domain.Models.Template;
using Template.Domain.Primitives;
using Template.Infrastructure.Mappers;

namespace Template.Infrastructure.Template.Mappers
{
    public interface ITemplateMapper<TFrom, TTo> : IMapper<TFrom> where TFrom : IEntity
    {
        public Task<TTo?> Map(TFrom from);
        public Task<TFrom?> Map(TTo to);
    }
}
