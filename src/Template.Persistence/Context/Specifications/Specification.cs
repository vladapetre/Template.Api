using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Template.Core.Primitives;

namespace Template.Persistence.Context.Specifications;

internal abstract record class Specification<TEntity> where TEntity : Entity
{
    protected Specification( Expression<Func<TEntity, bool>> criteria )
    {
        Criteria = criteria ?? (( e ) => true);
    }

    public Expression<Func<TEntity, bool>> Criteria { get; private init; }
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; private init; } = new();
    public List<Expression<Func<TEntity, object>>> OrderByExpressions { get; private init; } = new();

    protected void AddInclude( Expression<Func<TEntity, object>> includeExpression ) => IncludeExpressions.Add(includeExpression);
    protected void AddOrderBy( Expression<Func<TEntity, object>> orderByExpression ) => OrderByExpressions.Add(orderByExpression);
}

internal static class Specification
{
    public static IQueryable<TEntity> WithSpecification<TEntity>( this
        IQueryable<TEntity> queryable,
        Specification<TEntity> specification )
        where TEntity : Entity
    {
        if (specification == null)
        {
            return queryable;
        }

        if (specification.Criteria is not null)
        {
            queryable = queryable.Where(specification.Criteria);
        }

        if (specification.IncludeExpressions is not null)
        {
            queryable = specification.IncludeExpressions.Aggregate(
                            queryable,
                            ( current, includeExpression ) =>
                            current.Include(includeExpression));
        }

        if (specification.OrderByExpressions is not null)
        {
            queryable = specification.OrderByExpressions.Aggregate(
                            queryable,
                            ( current, orderByExpression ) =>
                            current.OrderBy(orderByExpression));
        }

        return queryable;
    }
}
