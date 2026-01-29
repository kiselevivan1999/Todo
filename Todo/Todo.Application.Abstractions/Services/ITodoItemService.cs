using Todo.Application.Contracts.Dtos.TodoItem;

namespace Todo.Application.Abstractions.Services;

public interface ITodoItemService
{
    /// <summary>
    /// Получить все задачи по фильтру
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TodoItemDto[]> GetByFilterAsync(TodoItemFilterDto filter,
        CancellationToken cancellationToken);
    /// <summary>
    /// Получить конкретную запись по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TodoItemDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    /// <summary>
    /// Создание записи
    /// </summary>
    /// <param name="createDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Созданная запись</returns>
    Task<TodoItemDto> CreateAsync(CreateTodoItemDto createDto,
        CancellationToken cancellationToken);
    /// <summary>
    /// Обновление записи
    /// </summary>
    /// <param name="updateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Обнавленная запись</returns>
    Task<TodoItemDto> UpdateAsync(int id, UpdateTodoItemDto updateDto,
        CancellationToken cancellationToken);
    /// <summary>
    /// Удалить задачу
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    /// <summary>
    /// Отметить задачу выполненной
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Измененная задача</returns>
    Task<TodoItemDto> CompleteAsync(int id, CancellationToken cancellationToken);
}
