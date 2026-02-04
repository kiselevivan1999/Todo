using Todo.Application.Repositories.Abstractions;
using Todo.Application.Repositories.Abstractions.Repositories;
using Todo.Infrastructure.EntityFramework.Context;

namespace Todo.Infrastructure.Repositories.Implementations;

internal class UnitOfWork : IUnitOfWork
{

    private ITodoItemRepository _todoItemRepository;
    private TodoDbContext _context;

    public ITodoItemRepository TodoItemRepository => _todoItemRepository;

    public UnitOfWork(TodoDbContext context, ITodoItemRepository todoItemRepository) 
    {
        _context = context;
        _todoItemRepository = todoItemRepository;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
