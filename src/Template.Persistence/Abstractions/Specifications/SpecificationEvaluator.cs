namespace Template.Persistence.Abstractions.Specifications;
internal static class SpecificationEvaluator
{
    public static IQueryable<TEntity> WithSpecification<TEntity>(this
        IQueryable<TEntity> queryable,
        Specification<TEntity> specification)
        where TEntity : class, IEntity
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
                            (current, includeExpression) =>
                            current.Include(includeExpression));
        }

        if (specification.OrderByExpressions is not null)
        {
            queryable = specification.OrderByExpressions.Aggregate(
                            queryable,
                            (current, orderByExpression) =>
                            current.OrderBy(orderByExpression));
        }

        return queryable;
    }
}
