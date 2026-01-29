using System.Linq.Expressions;

namespace Todo.Application.Abstractions.Specifications;

public interface ISpecification<T> 
{
    public abstract Expression<Func<T, bool>> ToExpression();
    public bool IsSatisfiedBy(T entity);
}
