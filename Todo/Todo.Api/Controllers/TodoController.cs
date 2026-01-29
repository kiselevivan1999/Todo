using Microsoft.AspNetCore.Mvc;
using Todo.Application.Abstractions.Services;
using Todo.Application.Contracts.Dtos.TodoItem;

namespace Todo.Api.Controllers;

[ApiController]
[Route("api/todos")]
public class TodoController : ControllerBase
{
    private readonly ITodoItemService _todoItemService;

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
    [ProducesResponseType(typeof(TodoItemDto[]), StatusCodes.Status200OK)]
    public async Task<ActionResult<TodoItemDto[]>> GetByFilter([FromQuery] TodoItemFilterDto filter, 
        CancellationToken cancellationToken) 
    {
        var result = await _todoItemService.GetByFilterAsync(filter, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Получить конкретную запись по id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TodoItemDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(typeof(TodoItemDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TodoItemDto>> Create(CreateTodoItemDto createDto,
        CancellationToken cancellationToken)
    {
        var result = await _todoItemService.CreateAsync(createDto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = result.Id}, result);
    }

    /// <summary>
    /// Обновление записи
    /// </summary>
    /// <param name="updateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Обнавленная запись</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(TodoItemDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken) 
    {
        await _todoItemService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }

    /// <summary>
    /// Отметить задачу выполненной
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Измененная задача</returns>
    [HttpPatch("{id}/complete")]
    [ProducesResponseType(typeof(TodoItemDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TodoItemDto>> Complete(int id,
        CancellationToken cancellationToken) 
    {
        var result = await _todoItemService.CompleteAsync(id, cancellationToken);
        return Ok(result);
    }
}
