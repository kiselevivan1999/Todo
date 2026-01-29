namespace Todo.Application.Contracts.Dtos.TodoItem;

public record UpdateTodoItemDto
{
    /// <summary>
    /// Наименование задачи. Обязательно.
    /// </summary>
    public required string Title { get; set; }
    /// <summary>
    /// Описание задачи. Опционально.
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Приоритет задачи.
    /// </summary>
    public int Priority { get; set; }
}
