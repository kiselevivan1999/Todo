using Todo.Application.Repositories.Abstractions.Repositories;
using Todo.Domain.Entities;
using Todo.Infrastructure.Repositories.Implementations.Generic;
using Todo.Infrastructure.EntityFramework.Context;

namespace Todo.Infrastructure.Repositories.Implementations.Repositories;

internal class TodoItemRepository : GenericRepository<TodoItem, int>, ITodoItemRepository
{
    public TodoItemRepository(TodoDbContext context) : base(context)
    {
    }
}
