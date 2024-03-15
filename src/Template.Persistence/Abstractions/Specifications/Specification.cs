using System.Linq.Expressions;
using Template.Domain.Abstractions.Primitives;

namespace Template.Persistence.Abstractions.Specifications;
internal abstract class Specification<TEntity> where TEntity : IEntity
{
    protected Specification(Expression<Func<TEntity, bool>>? criteria = null)
    {
        Criteria = criteria;
    }
    public Expression<Func<TEntity, bool>>? Criteria { get; private init; } = default!;
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; private init; } = new();
    public List<Expression<Func<TEntity, object>>> OrderByExpressions { get; private init; } = new();

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) => IncludeExpressions.Add(includeExpression);
    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) => OrderByExpressions.Add(orderByExpression);
}
