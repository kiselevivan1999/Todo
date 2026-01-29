using System.Linq.Expressions;
using Todo.Application.Abstractions.Specifications;

namespace Todo.Application.Implementations.Specifications;

internal abstract class Specification<T> : ISpecification<T>
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public bool IsSatisfiedBy(T entity)
        => ToExpression().Compile().Invoke(entity);
}
