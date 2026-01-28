using Todo.Domain.Entities;
using Todo.Application.Repositories.Abstractions.Generic;

namespace Todo.Application.Repositories.Abstractions.Repositories;

public interface ITodoItemRepository : IGenericRepository<TodoItem, int>
{

}
