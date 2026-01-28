using Microsoft.AspNetCore.Mvc;
using Todo.Application.Abstractions.Services;
using Todo.Application.Contracts.Dtos.TodoItem;

namespace Todo.Api.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoController : ControllerBase
{
    private readonly ITodoItemService _todoItemService;

    //TODO: Возвращать нормальные коды ответов
    public TodoController(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }

    /// <summary>
    /// Получить все задачи по фильтру
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<TodoItemDto[]> GetByFilter(TodoItemFilterDto filter) 
    {
        var result = _todoItemService.GetByFilter(filter);
        return Ok(result);
    }

    /// <summary>
    /// Получить конкретную запись по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDto>> GetById(int id, 
        CancellationToken cancellationToken)
    {
        var result = await _todoItemService.GetByIdAsync(id, cancellationToken);
        return Ok(result);
    }
    /// <summary>
    /// Создание записи
    /// </summary>
    /// <param name="createDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Созданная запись</returns>
    [HttpPost]
    public async Task<ActionResult<TodoItemDto>> Create(CreateTodoItemDto createDto,
        CancellationToken cancellationToken)
    {
        var result = await _todoItemService.CreateAsync(createDto, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Обновление записи
    /// </summary>
    /// <param name="updateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Обнавленная запись</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<TodoItemDto>> Update(int id, 
        UpdateTodoItemDto updateDto,
        CancellationToken cancellationToken)
    {
        var result = await _todoItemService.UpdateAsync(id, updateDto, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Удалить задачу
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken) 
    {
        await _todoItemService.DeleteAsync(id, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Отметить задачу выполненной
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Измененная задача</returns>
    [HttpPatch("{id}")]
    public async Task<ActionResult<TodoItemDto>> Complete(int id,
        CancellationToken cancellationToken) 
    {
        var result = await _todoItemService.CompleteAsync(id, cancellationToken);
        return Ok(result);
    }
}
