using Todo.Domain.Enums;

namespace Todo.Domain.Entities;

/// <summary>
/// Задача
/// </summary>
public class TodoItem : IEntity<int>
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; private set; }
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
    public bool IsCompleted { get; private set; } = false;
    /// <summary>
    /// Приоритет задачи.
    /// </summary>
    public PriorityEnum Priority { get; set; }
    /// <summary>
    /// Дата начала задачи. Заполняется автоматически.
    /// </summary>
    public DateTime CreatedAt { get; } = DateTime.Now;
    /// <summary>
    /// Дата завершения задачи. Заполняется при выполнении.
    /// </summary>
    public DateTime? CompletedAt { get; private set; }

    /// <summary>
    /// Помечаем задачу выполненной
    /// </summary>
    public void Complete() 
    {
        IsCompleted = true;
        CompletedAt = DateTime.Now;
    }
}
