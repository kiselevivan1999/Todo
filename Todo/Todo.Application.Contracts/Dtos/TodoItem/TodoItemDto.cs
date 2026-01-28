namespace Todo.Application.Contracts.Dtos.TodoItem;

public class TodoItemDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Наименование задачи. Обязательно.
    /// </summary>
    public required string Title { get; set; }
    /// <summary>
    /// Описание задачи. Опционально.
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// Выполнена ли задача. (false - не выполнена, true - выполнена)
    /// </summary>
    public bool IsCompleted { get; set; } = false;
    /// <summary>
    /// Приоритет задачи.
    /// </summary>
    public int Priority { get; set; }
    /// <summary>
    /// Дата начала задачи. Заполняется автоматически.
    /// </summary>
    public DateTime CreatedAt { get; set; }
    /// <summary>
    /// Дата завершения задачи. Заполняется при выполнении.
    /// </summary>
    public DateTime? CompletedAt { get; set; }
}
