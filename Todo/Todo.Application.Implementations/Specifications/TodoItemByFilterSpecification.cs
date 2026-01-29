using System.Linq.Expressions;
using Todo.Application.Abstractions.Specifications;
using Todo.Domain.Entities;

namespace Todo.Application.Implementations.Specifications;

internal class TodoItemByFilterSpecification : Specification<TodoItem>, ISpecification<TodoItem>
{
    private readonly bool? _isCompleted;
    private readonly int? _priority;

    public TodoItemByFilterSpecification(bool? isCompleted, int? priority) : base()
    {
        _isCompleted = isCompleted;
        _priority = priority;
    }

    public override Expression<Func<TodoItem, bool>> ToExpression()
    {
        return item =>
           (!_isCompleted.HasValue || item.IsCompleted == _isCompleted.Value) &&
           (!_priority.HasValue || (int)item.Priority == _priority.Value);
    }
}
