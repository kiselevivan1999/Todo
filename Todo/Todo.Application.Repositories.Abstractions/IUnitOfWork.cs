using Todo.Application.Repositories.Abstractions.Repositories;

namespace Todo.Application.Repositories.Abstractions;

public interface IUnitOfWork
{
    ITodoItemRepository TodoItemRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
