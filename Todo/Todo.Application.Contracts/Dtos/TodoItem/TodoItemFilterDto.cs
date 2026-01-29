namespace Todo.Application.Contracts.Dtos.TodoItem;

public record TodoItemFilterDto
{
    /// <summary>
    /// Фильтр по статусу выполнения
    /// </summary>
    public bool? IsCompleted { get; set; }

    /// <summary>
    /// фильтр по приоритету
    /// </summary>
    public int? Priority { get; set; }
}
